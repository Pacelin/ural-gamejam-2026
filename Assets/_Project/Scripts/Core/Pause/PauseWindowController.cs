using System;
using Project.Achievements;
using Project.Core.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core.Pause
{
    public class PauseWindowController : EscapeWindowController<PauseWindow>, IInitializable, IDisposable
    {
        private readonly PauseController _pauseController;
        private readonly AchievementsButtonController _achievementsButtonController;
        
        public PauseWindowController(PauseWindow window, EscapeController escapeController,
            PauseController pauseController,
            AchievementsModel achievements, AchievementsWindowController achievementsWindow) :
            base (window, escapeController)
        {
            _pauseController = pauseController;
            _achievementsButtonController = new AchievementsButtonController(
                Window.AchievementsButton, achievements, achievementsWindow);
        }
        
        public void Initialize()
        {
            EscapeController.OnEscapeWithEmptyStack += Show;
            Window.MainMenuButton.onClick.AddListener(QuitToMainMenu);
            Window.ResumeButton.onClick.AddListener(Hide);
            
            _achievementsButtonController.Initialize();
        }

        public void Dispose()
        {
            EscapeController.OnEscapeWithEmptyStack -= Show;
            Window.MainMenuButton.onClick.RemoveListener(QuitToMainMenu);
            Window.ResumeButton.onClick.RemoveListener(Hide);

            _achievementsButtonController.Dispose();
        }

        public override void Show()
        {
            _pauseController.SetPause(EPauseState.PausedByUser, true);
            _achievementsButtonController.UpdateState();
            base.Show();
        }

        public override void Hide()
        {
            _pauseController.SetPause(EPauseState.PausedByUser, false);
            base.Hide();
        }

        private void QuitToMainMenu()
        {
            _pauseController.SetPause(EPauseState.PausedByUser, false);
            SceneManager.LoadScene(1);
        }
    }
}