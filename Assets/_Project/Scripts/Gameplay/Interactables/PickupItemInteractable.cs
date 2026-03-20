using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PickupItemInteractable : InteractableObjectWithCursor
    {
        [SerializeField] private InventoryItemConfig _itemConfig;
        [SerializeField] private GameObject _destroyObject;
        [SerializeField] private SoundEvent _pickupSound;

        private InventoryModel _inventory;

        protected override ECursorState HoverCursorState => ECursorState.HoverPickup;
        protected override ECursorState DownCursorState => ECursorState.HoverPickup;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _inventory = resolver.Resolve<InventoryModel>();
        }

        protected override void OnInteract()
        {
            _inventory.AddItem(_itemConfig);
            _pickupSound.PlayOneShot();
            AfterInteract();
        }

        protected virtual void AfterInteract()
        {
            Destroy(_destroyObject);
        }
    }
}