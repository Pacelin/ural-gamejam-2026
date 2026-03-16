using System.Collections.Generic;
using JetBrains.Annotations;

namespace Project.Gameplay.Inventory
{
    [UsedImplicitly]
    public class InventoryModel
    {
        public event System.Action<int> OnAddItem;
        public event System.Action<int> OnRemoveItem;
        public event System.Action<int, int> OnSelectionChanged;

        public int SelectedIndex => _selectedIndex;
        public IReadOnlyList<InventoryItemConfig> Items => _items;

        private int _selectedIndex;
        
        private readonly List<InventoryItemConfig> _items;

        public InventoryModel(InventoryItemConfig[] initialItems)
        {
            _items = new List<InventoryItemConfig>(initialItems);
        }
        
        public void ResetSelection()
        {
            var prevValue = _selectedIndex;
            _selectedIndex = -1;
            OnSelectionChanged?.Invoke(prevValue, _selectedIndex);
        }

        public void SetSelected(int index)
        {
            var prevValue = _selectedIndex;
            _selectedIndex = index;
            OnSelectionChanged?.Invoke(prevValue, _selectedIndex);
        }
        
        public void AddItem(InventoryItemConfig item)
        {
            _items.Add(item);
            OnAddItem?.Invoke(_items.Count - 1);
        }

        public void RemoveAt(int index)
        {
            if (_selectedIndex == index)
                ResetSelection();
            else if (_selectedIndex > index)
                _selectedIndex--;
            _items.RemoveAt(index);
            OnRemoveItem?.Invoke(index);
        }
        
        public void RemoveItem(InventoryItemConfig item)
        {
            var index = _items.IndexOf(item);
            RemoveAt(index);
        }

        public bool HasItem(InventoryItemConfig item)
        {
            return _items.Contains(item);
        }
    }
}