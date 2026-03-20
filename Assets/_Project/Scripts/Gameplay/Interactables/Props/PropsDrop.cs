using Project.Gameplay.Inventory;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsDrop : NotInteractableObject, IInventoryItemDropTarget
    {
        [SerializeField] private InventoryItemConfig _requireItem;
        [SerializeField] private PropsEvents _afterDrop;

        private InventoryModel _inventory;

        protected override void Initialize(IObjectResolver resolver)
        {
            _inventory = resolver.Resolve<InventoryModel>();
            _afterDrop.Prepare();
        }
        
        public bool CanDrop(InventoryItemEntry item) => item.Config == _requireItem;
        public void OnDrop(InventoryItemEntry item)
        {
            item.Config.PutSound.PlayOneShotInPoint(transform.position);
            _inventory.RemoveItem(item);
            _afterDrop.Trigger();
        }
    }
}