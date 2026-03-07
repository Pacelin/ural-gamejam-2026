using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Plugins.Extras
{
    public class PauseManager : ManagerBase
    {
        [SerializeField] private PauseWindow _pauseWindowPrefab;
        
        public static event Action RestartRequest
        {
            add => _pauseWindow.RestartRequest += value;
            remove => _pauseWindow.RestartRequest -= value;
        }

        public static IReadOnlyAsyncReactiveProperty<EPauseState> CurrentState => _pauseState;

        private static AsyncReactiveProperty<EPauseState> _pauseState;
        private static HashSet<EPauseState> _pausesRequests;
        private static PauseWindow _pauseWindow;
        private static bool _pauseWindowShowed;

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
            }
            else if (!result.HasFlag(EPauseState.PausedByUser) && _pauseWindowShowed)
            {
                _pauseWindow.Hide();
                _pauseWindowShowed = false;
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