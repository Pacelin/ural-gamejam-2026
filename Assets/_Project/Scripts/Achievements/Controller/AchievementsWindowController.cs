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
            Window.BackButton.onClick.AddListener(Hide);
            
            _listController.Initialize();
            _infoController.Initialize();
        }

        public void Dispose()
        {
            Window.BackButton.onClick.RemoveListener(Hide);
            
            _listController.Dispose();
            _infoController.Dispose();
        }

        public void Show(AchievementConfig achievement)
        {
            _listController.SetSelectedAchievement(achievement);
            _listController.UpdateList(true);
            _infoController.UpdateSelection(true);
            _pauseController.SetPause(EPauseState.PausedByAchievements, true);
            base.Show();
        }

        public override void Show()
        {
            _listController.SetSelectedIndex(0);
            _listController.UpdateList(true);
            _infoController.UpdateSelection(true);
            _pauseController.SetPause(EPauseState.PausedByAchievements, false);
            base.Show();
        }
    }
}