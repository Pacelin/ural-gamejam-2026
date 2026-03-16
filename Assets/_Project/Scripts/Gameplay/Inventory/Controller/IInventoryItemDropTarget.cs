namespace Project.Gameplay.Inventory
{
    public interface IInventoryItemDropTarget
    {
        bool CanDrop(InventoryItemEntry item);
        void OnDrop(InventoryItemEntry item);
    }
}