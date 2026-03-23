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
        public event System.Action<bool> OnViewStateChanged;
        
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

        public void DisableView()
        {
            OnViewStateChanged?.Invoke(false);
        }

        [PublicAPI]
        public void EnableView()
        {
            OnViewStateChanged?.Invoke(true);
        }
        
        public void RemoveItem(InventoryItemEntry inventoryItem)
        {
            _items.Remove(inventoryItem);
            OnRemoveItem?.Invoke(inventoryItem);
        }
    }
}