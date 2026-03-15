using Project.Achievements;

namespace Project.Core
{
    public class GameModel
    {
        private readonly AchievementsModel _achievements;
        
        public GameModel(AchievementsModel achievements)
        {
            _achievements = achievements;
        }
    }
}