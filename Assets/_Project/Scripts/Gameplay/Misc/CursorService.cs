using UnityEngine;

namespace Project.Gameplay.Misc
{
    public class CursorService : System.IDisposable
    {
        private readonly CursorSettings _settings;

        private bool _inventoryItemHover;
        private bool _inventoryItemHold;
        
        public CursorService(CursorSettings settings)
        {
            _settings = settings;
            _inventoryItemHover = false;
            _inventoryItemHold = false;
        }

        public void Dispose() => SetDefault();
        
        public void SetInventoryItemHover(bool isActive)
        {
            _inventoryItemHover = isActive;
            UpdateCursor();
        }

        public void SetInventoryItemHold(bool isActive)
        {
            _inventoryItemHold = isActive;
            UpdateCursor();
        }

        private void UpdateCursor()
        {
            if (_inventoryItemHold)
                SetCustom(_settings.HoldItem);
            else if (_inventoryItemHover)
                SetCustom(_settings.GrabItem);
            else
                SetDefault();
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