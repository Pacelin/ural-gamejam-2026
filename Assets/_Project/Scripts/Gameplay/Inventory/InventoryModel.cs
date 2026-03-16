using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Project.Gameplay.Inventory
{
    [UsedImplicitly]
    public class InventoryModel
    {
        public event System.Action<InventoryItemEntry> OnAddItem;
        public event System.Action<InventoryItemEntry> OnRemoveItem;

        public IReadOnlyList<InventoryItemEntry> Items => _items;

        private readonly List<InventoryItemEntry> _items;

        public InventoryModel(InventoryItemConfig[] initialItems)
        {
            _items = new List<InventoryItemEntry>(initialItems.Select(c => new InventoryItemEntry(c)));
        }
        
        public void AddItem(InventoryItemConfig item)
        {
            var itemEntry = new InventoryItemEntry(item);
            _items.Add(itemEntry);
            OnAddItem?.Invoke(itemEntry);
        }

        public void RemoveAt(int index) => RemoveItem(_items[index]);
        
        public void RemoveItem(InventoryItemEntry inventoryItem)
        {
            var index = _items.IndexOf(inventoryItem);
            RemoveAt(index);;
            OnRemoveItem?.Invoke(inventoryItem);
        }

        public bool HasItem(InventoryItemConfig item)
        {
            return _items.Any(i => i.Config == item);
        }
    }
}