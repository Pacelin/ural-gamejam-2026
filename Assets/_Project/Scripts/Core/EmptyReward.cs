using Project.Achievements;

namespace Project.Core
{
    [System.Serializable]
    public class EmptyReward : RewardConfig
    {
        public override void OnClaim(GameModel gameModel) { }
    }
}