using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Plugins.Audio;
using UnityEngine;
using VContainer.Unity;

namespace Project.Core.Pause
{
    public class PauseController : IInitializable, IDisposable
    {
        public IReadOnlyAsyncReactiveProperty<EPauseState> CurrentState => _pauseState;

        private AsyncReactiveProperty<EPauseState> _pauseState = new (EPauseState.None);
        private List<EPauseState> _pausesRequests = new ();

        public void Initialize()
        {
            Application.focusChanged += OnApplicationFocusChanged;
        }

        public void Dispose()
        {
            Application.focusChanged -= OnApplicationFocusChanged;
            _pauseState?.Dispose();
        }
        
        public void SetPause(EPauseState state, bool status)
        {
            if (_pausesRequests == null)
                return;
            
            if (status)
                _pausesRequests.Add(state);
            else if (_pausesRequests.Contains(state))
                _pausesRequests.Remove(state);
            UpdatePause();
        }
        
        private void UpdatePause()
        {
            EPauseState result = EPauseState.None;
            foreach (var request in _pausesRequests)
                result |= request;
            if (result != _pauseState.Value)
                _pauseState.Value = result;
            
            if (result.HasFlag(EPauseState.PausedByUser))
                AudioSystem.Global.SetPauseState(AudioSystem.Global.ELabel_PauseState.OnPause);
            else
                AudioSystem.Global.SetPauseState(AudioSystem.Global.ELabel_PauseState.NotOnPause);
        }

        private void OnApplicationFocusChanged(bool focus) => SetPause(EPauseState.PausedByApplication, !focus);
    }
}