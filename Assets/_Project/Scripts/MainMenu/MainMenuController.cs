using System;
using JetBrains.Annotations;
using Plugins.Audio;
using Project.Core.Audio;
using Project.Core.Misc;
using VContainer.Unity;

namespace Project.MainMenu
{
    [UsedImplicitly]
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly MainMenuWindow _mainMenuWindow;
        private readonly SceneLoader _sceneLoader;
        
        public MainMenuController(MainMenuWindow window, SceneLoader sceneLoader)
        {
            _mainMenuWindow = window;
            _sceneLoader = sceneLoader;
        }
        
        public void Initialize()
        {
            _mainMenuWindow.PlayButton.onClick.AddListener(OnPlayClicked);
            _mainMenuWindow.QuitButton.onClick.AddListener(OnQuitClicked);
            
            MusicController.SetMusic(AudioSystem.Music_BGM);
            MusicController.StopRoomTone();
        }

        public void Dispose()
        {
            _mainMenuWindow.PlayButton.onClick.RemoveListener(OnPlayClicked);
            _mainMenuWindow.QuitButton.onClick.RemoveListener(OnQuitClicked);
        }

        private void OnQuitClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }

        private void OnPlayClicked() => _sceneLoader.Load(2);
    }
}