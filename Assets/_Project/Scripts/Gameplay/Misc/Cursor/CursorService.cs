using JetBrains.Annotations;
using Project.Core.Pause;
using UnityEngine;
using VContainer.Unity;

namespace Project.Gameplay.Misc
{
    [UsedImplicitly]
    public class CursorService : IInitializable, System.IDisposable
    {
        private readonly CursorSettings _settings;
        private readonly PauseController _pauseController;

        private ECursorState _currentState;
        private System.IDisposable _pauseDisposable;
        
        public CursorService(CursorSettings settings, PauseController pauseController)
        {
            _settings = settings;
            _pauseController = pauseController;
            _currentState = ECursorState.None;
        }

        public void Initialize()
        {
            _pauseDisposable = _pauseController.SubscribeAnyPause(isPause =>
            {
                if (isPause)
                {
                    _currentState = ECursorState.None;
                    SetDefault();
                }
            });
        }

        public void Dispose()
        {
            _pauseDisposable.Dispose();
            SetDefault();
        }

        public void EnableCursorState(ECursorState state)
        {
            _currentState |= state;
            UpdateCursor();
        }

        public void DisableCursorState(ECursorState state)
        {
            _currentState &= ~state;
            UpdateCursor();
        }
        
        private void UpdateCursor()
        {
            if (_currentState == ECursorState.None)
            {
                SetDefault();
                return;
            }
            
            if (_currentState.HasFlag(ECursorState.HoldInventoryItem))
                SetCustom(_settings.HoldItem);
            else if (_currentState.HasFlag(ECursorState.HoverInventoryItem) ||
                     _currentState.HasFlag(ECursorState.HoverPickup))
                SetCustom(_settings.GrabItem);
            else if (_currentState.HasFlag(ECursorState.HoverQuestion))
                SetCustom(_settings.Question);
            else if (_currentState.HasFlag(ECursorState.HoverWalkObject))
                SetCustom(_settings.Walk);
            else if (_currentState.HasFlag(ECursorState.DownPointer))
                SetCustom(_settings.DownPointer);
            else if (_currentState.HasFlag(ECursorState.HoverPointer))
                SetCustom(_settings.Pointer);
            else if (_currentState.HasFlag(ECursorState.RotateLeft))
                SetCustom(_settings.RotateLeft);
            else if (_currentState.HasFlag(ECursorState.RotateRight))
                SetCustom(_settings.RotateRight);
            else if (_currentState.HasFlag(ECursorState.MoveBack))
                SetCustom(_settings.MoveBack);
        }

        private void SetCustom(CursorData cursorData)
        {
            Cursor.SetCursor(cursorData.CursorTexture, cursorData.Hotspot, CursorMode.Auto);
        }
        
        private void SetDefault()
        {
            Cursor.SetCursor(null, new Vector2(0.5f, 0.5f), CursorMode.Auto);
        }
    }
}