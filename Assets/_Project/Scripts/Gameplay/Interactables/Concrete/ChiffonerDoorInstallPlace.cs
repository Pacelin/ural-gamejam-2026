using Project.Gameplay.Inventory;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class ChiffonerDoorInstallPlace : NotInteractableObject, IInventoryItemDropTarget
    {
        [SerializeField] private InventoryItemConfig _doorItem;
        [SerializeField] private GameObject _door;

        private InventoryModel _inventory;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            _inventory = resolver.Resolve<InventoryModel>();
            _door.gameObject.SetActive(false);
        }
        
        public bool CanDrop(InventoryItemEntry item) => item.Config == _doorItem;
        public void OnDrop(InventoryItemEntry item)
        {
            _door.gameObject.SetActive(true);
            _inventory.RemoveItem(item);
            Destroy(gameObject);
        }
    }
}