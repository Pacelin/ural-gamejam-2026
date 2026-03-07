using System;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Extras
{
    public class PauseWindow : MonoBehaviour
    {
        public event Action RestartRequest;
        
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private bool _enableRestart;

        private void Awake()
        {
            _restartButton.gameObject.SetActive(_enableRestart);
            _quitButton.gameObject.SetActive(Application.platform != RuntimePlatform.WebGLPlayer);
        }

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(Resume);
            _restartButton.onClick.AddListener(Restart);
            _quitButton.onClick.AddListener(Quit);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(Resume);
            _restartButton.onClick.RemoveListener(Restart);
            _quitButton.onClick.RemoveListener(Quit);
        }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        private void Resume() => PauseManager.SetPause(EPauseState.PausedByUser, false);
        private void Restart() => RestartRequest?.Invoke();
        private void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}