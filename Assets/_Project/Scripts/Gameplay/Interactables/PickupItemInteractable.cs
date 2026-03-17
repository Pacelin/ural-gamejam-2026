using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PickupItemInteractable : InteractableObject
    {
        [SerializeField] private InventoryItemConfig _itemConfig;

        private CursorService _cursorService;
        private InventoryModel _inventory;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            _cursorService = resolver.Resolve<CursorService>();
            _inventory = resolver.Resolve<InventoryModel>();
        }

        protected override void OnInteract()
        {
            _inventory.AddItem(_itemConfig);
            AudioSystem.Game_PickupItem.PlayOneShot();
            Destroy(gameObject);
        }

        protected override void OnInteractorEnter() => _cursorService.EnableCursorState(ECursorState.HoverPickup);
        protected override void OnInteractorExit() => _cursorService.DisableCursorState(ECursorState.HoverPickup);
    }
}