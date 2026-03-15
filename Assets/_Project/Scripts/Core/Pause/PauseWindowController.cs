using System;
using Project.Core.Misc;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core.Pause
{
    public class PauseWindowController : EscapeWindowController<PauseWindow>, IInitializable, IDisposable
    {
        private readonly PauseController _pauseController;
        
        public PauseWindowController(PauseWindow window, EscapeController escapeController,
            PauseController pauseController) :
            base (window, escapeController)
        {
            _pauseController = pauseController;
        }
        
        public void Initialize()
        {
            EscapeController.OnEscapeWithEmptyStack += Show;
            Window.MainMenuButton.onClick.AddListener(QuitToMainMenu);
            Window.ResumeButton.onClick.AddListener(Hide);
        }

        public void Dispose()
        {
            EscapeController.OnEscapeWithEmptyStack -= Show;
            Window.MainMenuButton.onClick.RemoveListener(QuitToMainMenu);
            Window.ResumeButton.onClick.RemoveListener(Hide);
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
            _pauseController.SetPause(EPauseState.PausedByUser, false);
            SceneManager.LoadScene(1);
        }
    }
}