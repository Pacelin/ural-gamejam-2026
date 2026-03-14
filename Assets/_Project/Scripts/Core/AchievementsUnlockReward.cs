using Project.Achievements;
using UnityEngine;

namespace Project.Core
{
    [System.Serializable]
    public class AchievementsUnlockReward : RewardConfig
    {
        [SerializeField] private AchievementConfig[] _achievements;
        public override void OnClaim(GameModel gameModel) => gameModel.UnlockAchievements(_achievements);
    }
}