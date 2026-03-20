using System;
using System.Linq;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsPickup : InteractableObjectWithCursor
    {
        [SerializeField] private InventoryItemConfig _itemConfig;
        [SerializeField] private PropsEvents _afterPickup;
        
        private InventoryModel _inventory;

        protected override ECursorState HoverCursorState => ECursorState.HoverPickup;
        protected override ECursorState DownCursorState => ECursorState.HoverPickup;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _inventory = resolver.Resolve<InventoryModel>();
            _afterPickup.Prepare();
        }

        protected override void OnInteract()
        {
            _inventory.AddItem(_itemConfig);
            _itemConfig.PickupSound.PlayOneShotInPoint(transform.position);
            _afterPickup.Trigger();
        }
    }
}