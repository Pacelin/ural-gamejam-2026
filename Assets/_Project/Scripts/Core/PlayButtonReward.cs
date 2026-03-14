using Project.Achievements;

namespace Project.Core
{
    [System.Serializable]
    public class PlayButtonReward : RewardConfig
    {
        public override void OnClaim(GameModel gameModel) => gameModel.PlayButtonAvailable = true;
    }
}