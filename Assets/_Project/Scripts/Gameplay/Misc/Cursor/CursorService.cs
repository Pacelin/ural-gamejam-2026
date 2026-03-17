using UnityEngine;

namespace Project.Gameplay.Misc
{
    public class CursorService : System.IDisposable
    {
        private readonly CursorSettings _settings;

        private ECursorState _currentState;
        
        public CursorService(CursorSettings settings)
        {
            _settings = settings;
            _currentState = ECursorState.None;
        }

        public void Dispose() => SetDefault();

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
            else if (_currentState.HasFlag(ECursorState.HoverPointer))
                SetCustom(_settings.Pointer);
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