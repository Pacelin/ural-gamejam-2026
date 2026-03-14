using Project.Achievements;
using Project.Core.Misc;

namespace Project.Core
{
    public class GameModel
    {
        public event System.Action OnPlayButtonStateChanged;
        
        public bool PlayButtonAvailable
        {
            get => _playButtonAvailable.Value;
            set
            {
                _playButtonAvailable.Value = value;
                OnPlayButtonStateChanged?.Invoke();
            }
        }

        private readonly AchievementsModel _achievements;
        
        private readonly SaveBool _playButtonAvailable;
        
        public GameModel(AchievementsModel achievements)
        {
            _achievements = achievements;
        
            _playButtonAvailable = new SaveBool("playButtonAvailable", false);
        }

        public void UnlockAchievements(AchievementConfig[] achievements)
        {
            foreach (var achievement in achievements)
                _achievements.SetAchievementAvailable(achievement.Id);
        }
    }
}