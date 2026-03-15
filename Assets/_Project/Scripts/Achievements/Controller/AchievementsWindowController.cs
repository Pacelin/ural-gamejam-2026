using System;
using Project.Core.Misc;
using Project.Core.Pause;
using VContainer.Unity;

namespace Project.Achievements
{
    public class AchievementsWindowController : EscapeWindowController<AchievementsWindowView>, IInitializable, IDisposable
    {
        private readonly AchievementsModel _achievements;
        private readonly PurposesModel _purposes;
        private readonly PauseController _pauseController;
        private readonly AchievementsListController _listController;
        private readonly AchievementsInfoController _infoController;
        
        public AchievementsWindowController(AchievementsWindowView view, EscapeController escapeController,
            AchievementsModel achievements,
            PurposesModel purposes, PauseController pauseController) : base(view, escapeController)
        {
            _achievements = achievements;
            _purposes = purposes;
            _pauseController = pauseController;

            _listController = new AchievementsListController(
                view.ListView,
                _achievements);
            _infoController = new AchievementsInfoController(
                _listController,
                view.InfoView,
                _achievements,
                _purposes);
        }
        
        public void Initialize()
        {
            _listController.Initialize();
            _infoController.Initialize();
            
            _achievements.OnAchievementCompleted += OnAchievementCompleted;
            Window.CloseButton.onClick.AddListener(Hide);
        }

        public void Dispose()
        {
            _listController.Dispose();
            _infoController.Dispose();
            
            _achievements.OnAchievementCompleted -= OnAchievementCompleted;
            Window.CloseButton.onClick.RemoveListener(Hide);
        }

        public void Show(AchievementConfig achievement)
        {
            _listController.SetSelectedAchievement(achievement);
            _listController.UpdateList(true);
            _infoController.UpdateSelection(true);
            _pauseController.SetPause(EPauseState.PausedByAchievements, true);
            Window.SetAchievementsCount(_achievements.CompletedAchievementsCount, _achievements.AchievementCount);
            base.Show();
        }

        public override void Show()
        {
            _listController.SetSelectedIndex(0);
            _listController.UpdateList(true);
            _infoController.UpdateSelection(true);
            _pauseController.SetPause(EPauseState.PausedByAchievements, false);
            Window.SetAchievementsCount(_achievements.CompletedAchievementsCount, _achievements.AchievementCount);
            base.Show();
        }

        private void OnAchievementCompleted(string id)
        {
            if (Window.gameObject.activeInHierarchy)
                Window.SetAchievementsCount(_achievements.CompletedAchievementsCount, _achievements.AchievementCount);
        }
    }
}