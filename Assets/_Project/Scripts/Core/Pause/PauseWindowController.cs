using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Project.Achievements;
using Project.Core.Misc;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core.Pause
{
    [UsedImplicitly]
    public class PauseWindowController : EscapeWindowController<PauseWindow>, IInitializable, IDisposable
    {
        private readonly PauseController _pauseController;
        private readonly AchievementsButtonController _achievementsButtonController;
        private readonly AcceptPopup _acceptPopup;
        
        public PauseWindowController(PauseWindow window, EscapeController escapeController,
            PauseController pauseController, AchievementsWindowController achievementsWindow,
            AcceptPopup acceptPopup) :
            base (window, escapeController)
        {
            _pauseController = pauseController;
            _acceptPopup = acceptPopup;
            _achievementsButtonController = new AchievementsButtonController(
                Window.AchievementsButton, achievementsWindow);
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
            base.Show();
        }

        public override void Hide()
        {
            _pauseController.SetPause(EPauseState.PausedByUser, false);
            base.Hide();
        }

        private void QuitToMainMenu()
        {
            UniTask.Void(async () =>
            {
                if (await _acceptPopup.Show(EscapeController))
                {
                    _pauseController.SetPause(EPauseState.PausedByUser, false);
                    SceneManager.LoadScene(1);
                }
            });
        }
    }
}