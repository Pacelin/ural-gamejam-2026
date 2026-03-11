using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Plugins.Audio;
using UnityEngine;

namespace Plugins.Extras
{
    public class PauseManager : ManagerBase
    {
        [SerializeField] private PauseWindow _pauseWindowPrefab;
        [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
        
        public static event Action RestartRequest
        {
            add => _pauseWindow.RestartRequest += value;
            remove => _pauseWindow.RestartRequest -= value;
        }

        public static IReadOnlyAsyncReactiveProperty<EPauseState> CurrentState => _pauseState;
        public static bool HandlePauseByKey { get; set; }

        private static AsyncReactiveProperty<EPauseState> _pauseState;
        private static HashSet<EPauseState> _pausesRequests;
        private static PauseWindow _pauseWindow;
        private static bool _pauseWindowShowed;

        private void Update()
        {
            if (!HandlePauseByKey)
                return;
            if (Input.GetKeyDown(_pauseKey))
            {
                bool pausedNow = _pausesRequests.Contains(EPauseState.PausedByUser);
                SetPause(EPauseState.PausedByUser, !pausedNow);
            }
        }

        public static void SetPause(EPauseState state, bool status)
        {
            if (_pausesRequests == null)
                return;
            
            if (status)
                _pausesRequests.Add(state);
            else if (_pausesRequests.Contains(state))
                _pausesRequests.Remove(state);
            UpdatePause();
        }

        private static void UpdatePause()
        {
            EPauseState result = EPauseState.None;
            foreach (var request in _pausesRequests)
                result |= request;
            if (result != _pauseState.Value)
                _pauseState.Value = result;

            if (result.HasFlag(EPauseState.PausedByUser) && !_pauseWindowShowed)
            {
                _pauseWindow.Show();
                _pauseWindowShowed = true;
                AudioSystem.Global.SetPauseState(AudioSystem.Global.ELabel_PauseState.OnPause);
            }
            else if (!result.HasFlag(EPauseState.PausedByUser) && _pauseWindowShowed)
            {
                _pauseWindow.Hide();
                _pauseWindowShowed = false;
                AudioSystem.Global.SetPauseState(AudioSystem.Global.ELabel_PauseState.NotOnPause);
            }
        }
        
        internal override UniTask Initialize(CancellationToken cancellationToken)
        {
            _pauseState = new AsyncReactiveProperty<EPauseState>(EPauseState.None);
            _pausesRequests = new HashSet<EPauseState>();
            
            cancellationToken.Register(() =>
            {
                _pauseState.Dispose();
            });

            _pauseWindow = Instantiate(_pauseWindowPrefab);
            DontDestroyOnLoad(_pauseWindow.gameObject);
            _pauseWindow.gameObject.SetActive(false);
            
            return UniTask.CompletedTask;
        }

        private void OnApplicationPause(bool pauseStatus) => SetPause(EPauseState.PausedByApplication, pauseStatus);
    }
}