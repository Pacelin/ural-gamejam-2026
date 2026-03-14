using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Project.Core.Misc;
using VContainer.Unity;

namespace Project.Achievements
{
    [UsedImplicitly]
    public class AchievementsModel : IInitializable, System.IDisposable
    {
        public event System.Action<string> OnAchievementCompleted;
        public event System.Action<string> OnClaimReward;
        public event System.Action<string> OnAchievementBecomeAvailable;

        private readonly Dictionary<string, AchievementConfig> _allAchievements;
        private readonly Dictionary<string, AchievementData> _dataDictionary;
        private readonly PurposesModel _purposes;
        private readonly SavePoint<AchievementData[]> _savePoint;

        public AchievementsModel(AchievementConfig[] allAchievements, PurposesModel purposes)
        {
            _allAchievements = allAchievements.ToDictionary(a => a.Id);
            _dataDictionary = allAchievements.ToDictionary(a => a.Id, a => new AchievementData()
            {
                Id = a.Id,
                Available = false,
                Completed = false,
                RewardsClaimed = false
            });

            _purposes = purposes;
            _savePoint = new SavePoint<AchievementData[]>("achievements");
            
            if (_savePoint.HasSave())
            {
                var data = _savePoint.Load();
                foreach (var achievementData in data)
                    if (_dataDictionary.ContainsKey(achievementData.Id))
                        _dataDictionary[achievementData.Id] = achievementData;
            }
        }

        public void Initialize() => _purposes.OnPurposeUpdate += OnPurposeUpdate;
        public void Dispose() => _purposes.OnPurposeUpdate -= OnPurposeUpdate;
        
        public AchievementConfig GetAchievement(string id) => _allAchievements[id];
        
        public IEnumerable<AchievementConfig> GetAvailableAchievements()
        {
            foreach (var data in _dataDictionary.Values)
                if (data.Available)
                    yield return _allAchievements[data.Id];
        }

        public void SetAchievementAvailable(string id)
        {
            if (_dataDictionary[id].Available)
                return;
            
            _dataDictionary[id].Available = true;
            SaveData();
            OnAchievementBecomeAvailable?.Invoke(id);
            
            CheckCompletion(_allAchievements[id]);
        }

        public void ClaimRewards(string id)
        {
            if (_dataDictionary[id].RewardsClaimed)
                return;
            
            _dataDictionary[id].RewardsClaimed = true;
            SaveData();
            OnClaimReward?.Invoke(id);
        }

        public bool HasAchievementWithRewards()
        {
            foreach (var data in _dataDictionary.Values)
                if (data.Available && data.Completed && !data.RewardsClaimed)
                    return true;
            return false;
        }

        public bool IsAchievementCompleted(string id) => _dataDictionary[id].Completed;
        public bool IsRewardsClaimed(string id)
        {
            var achievement = _allAchievements[id];
            if (achievement.Rewards.Count == 0)
                return true;
            
            return _dataDictionary[id].RewardsClaimed;
        } 
        
        private void OnPurposeUpdate(EPurpose purpose, int current)
        {
            foreach (var data in _dataDictionary.Values)
            {
                if (!data.Available || data.Completed)
                    continue;
                var achievement = _allAchievements[data.Id];
                if (achievement.PurposeTargets.Any(p => p.Purpose.Id == purpose))
                    CheckCompletion(achievement);
            }
        }

        private void CheckCompletion(AchievementConfig achievement)
        {
            foreach (var purposeTarget in achievement.PurposeTargets)
            {
                var current = _purposes.GetPurposeProgress(purposeTarget.Purpose.Id);
                var target = purposeTarget.Target;
                if (current < target)
                    return;
            }

            _dataDictionary[achievement.Id].Completed = true;
            SaveData();
            OnAchievementCompleted?.Invoke(achievement.Id);
        }

        private void SaveData() => _savePoint.Save(_dataDictionary.Values.ToArray());
    }
}