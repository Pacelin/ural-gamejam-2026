using UnityEngine;

namespace Project.Gameplay.Inventory
{
    public class InventoryItemEntry
    {
        public Sprite Icon => _config.Icon;
        public string Text => _config.Text;
        public InventoryItemConfig Config => _config;
        
        private readonly InventoryItemConfig _config;
        
        public InventoryItemEntry(InventoryItemConfig config) => _config = config;
    }
}