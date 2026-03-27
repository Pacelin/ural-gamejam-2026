using Project.Gameplay.Interactables;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleFloppyPickup : InteractableObjectWithCursor
    {
        [SerializeField] private BasementConsoleFloppy _floppy;
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
            _inventory.AddItem(_floppy.FloppyItem);
            _floppy.FloppyItem.PickupSound.PlayOneShot();
            _afterPickup.Trigger(SubtitlesService);
        }
    }
}