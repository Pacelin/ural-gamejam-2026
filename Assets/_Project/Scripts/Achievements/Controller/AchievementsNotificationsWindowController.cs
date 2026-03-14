using System;
using VContainer.Unity;

namespace Project.Achievements
{
    public class AchievementsNotificationsWindowController : IInitializable, IDisposable
    {
        private readonly AchievementsNotificationWindowView _view;
        private readonly AchievementsModel _achievements;
        private readonly AchievementsWindowController _achievementsWindowController;
        
        public AchievementsNotificationsWindowController(AchievementsNotificationWindowView view,
            AchievementsModel achievements, AchievementsWindowController achievementsWindowController)
        {
            _view = view;
            _achievements = achievements;
            _achievementsWindowController = achievementsWindowController;
        }
        
        public void Initialize()
        {
            _view.GoToButton.onClick.AddListener(OnGoToClick);
            _achievements.OnAchievementCompleted += OnAchievementCompleted;
        }

        public void Dispose()
        {
            _view.GoToButton.onClick.RemoveListener(OnGoToClick);
            _achievements.OnAchievementCompleted += OnAchievementCompleted;
        }
        
        private void OnGoToClick()
        {
            var achievement = _achievements.GetAchievement(_view.ActiveAchievementId);
            _achievementsWindowController.Show(achievement);
        }

        private void OnAchievementCompleted(string id)
        {
            _view.Notify(id);
        }
    }
}