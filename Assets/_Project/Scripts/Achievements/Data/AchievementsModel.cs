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

        public int AchievementCount => _allAchievements.Count;
        public int CompletedAchievementsCount => _allAchievements.Count(pair => _dataDictionary[pair.Key].Completed);
        public IEnumerable<AchievementConfig> Achievements => _allAchievements.Values;

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
                Completed = false
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
        
        public bool IsAchievementCompleted(string id) => _dataDictionary[id].Completed;
        
        private void OnPurposeUpdate(EPurpose purpose, int current)
        {
            foreach (var data in _dataDictionary.Values)
            {
                if (data.Completed)
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