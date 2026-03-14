using System;
using JetBrains.Annotations;
using Plugins.Audio;
using Project.Achievements;
using Project.Core;
using Project.Core.Audio;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.MainMenu
{
    [UsedImplicitly]
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly MainMenuWindow _mainMenuWindow;
        private readonly GameModel _gameModel;
        private readonly AchievementsButtonController _achievementsButtonController;
        
        public MainMenuController(MainMenuWindow window, 
            AchievementsWindowController achievementsWindowController,
            AchievementsModel achievements,
            GameModel gameModel)
        {
            _mainMenuWindow = window;
            _gameModel = gameModel;

            _achievementsButtonController = new AchievementsButtonController(window.AchievementsButton,
                achievements, achievementsWindowController);
        }
        
        public void Initialize()
        {
            _mainMenuWindow.PlayButton.onClick.AddListener(OnPlayClicked);
            _mainMenuWindow.QuitButton.onClick.AddListener(OnQuitClicked);
            _gameModel.OnPlayButtonStateChanged += UpdatePlayButtonState;
            _achievementsButtonController.Initialize();
            UpdatePlayButtonState();
            _achievementsButtonController.UpdateState();
            
            MusicController.SetMusic(AudioSystem.Music_BGM);
        }

        public void Dispose()
        {
            _mainMenuWindow.PlayButton.onClick.RemoveListener(OnPlayClicked);
            _mainMenuWindow.QuitButton.onClick.RemoveListener(OnQuitClicked);
            _gameModel.OnPlayButtonStateChanged -= UpdatePlayButtonState;
            _achievementsButtonController.Dispose();
        }

        private void OnQuitClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }

        private void OnPlayClicked() => SceneManager.LoadScene(2);

        private void UpdatePlayButtonState()
        {
            _mainMenuWindow.PlayButton.gameObject.SetActive(_gameModel.PlayButtonAvailable);
            _mainMenuWindow.QuitButton.gameObject.SetActive(_gameModel.PlayButtonAvailable);
        }
    }
}