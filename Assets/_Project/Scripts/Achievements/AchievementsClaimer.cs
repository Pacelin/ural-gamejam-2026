using System;
using JetBrains.Annotations;
using Project.Core;
using VContainer.Unity;

namespace Project.Achievements
{
    [UsedImplicitly]
    public class AchievementsClaimer : IInitializable, IDisposable
    {
        private readonly AchievementsModel _achievements;
        private readonly GameModel _gameModel;
        
        public AchievementsClaimer(AchievementsModel achievements, GameModel gameModel)
        {
            _achievements = achievements;
            _gameModel = gameModel;
        }

        public void Initialize()
        {
            _achievements.OnClaimReward += OnClaimAchievementReward;
        }

        public void Dispose()
        {
            _achievements.OnClaimReward -= OnClaimAchievementReward;
        }

        private void OnClaimAchievementReward(string id)
        {
            var achievement = _achievements.GetAchievement(id);
            foreach (var reward in achievement.Rewards)
                reward.OnClaim(_gameModel);
        }
    }
}