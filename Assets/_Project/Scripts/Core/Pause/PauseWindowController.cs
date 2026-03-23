using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Project.Core.Misc;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core.Pause
{
    [UsedImplicitly]
    public class PauseWindowController : EscapeWindowController<PauseWindow>, IInitializable, IDisposable
    {
        private readonly PauseController _pauseController;
        private readonly AcceptPopup _acceptPopup;
        private readonly SceneLoader _sceneLoader;
        
        public PauseWindowController(PauseWindow window, EscapeController escapeController,
            PauseController pauseController, 
            AcceptPopup acceptPopup,
            SceneLoader sceneLoader) :
            base (window, escapeController)
        {
            _pauseController = pauseController;
            _acceptPopup = acceptPopup;
            _sceneLoader = sceneLoader;
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
            UniTask.Void(async () =>
            {
                if (await _acceptPopup.Show(EscapeController))
                {
                    _pauseController.SetPause(EPauseState.PausedByUser, false);
                    _sceneLoader.Load(1);
                }
            });
        }
    }
}