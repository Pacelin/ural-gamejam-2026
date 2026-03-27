using Project.Gameplay.Interactables;
using Project.Gameplay.Inventory;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleFloppyDrop : NotInteractableObject, IInventoryItemDropTarget
    {
        [SerializeField] private BasementConsoleFloppy _floppy;
        [SerializeField] private PropsEvents _afterDrop;

        private InventoryModel _inventory;

        protected override void Initialize(IObjectResolver resolver)
        {
            _inventory = resolver.Resolve<InventoryModel>();
        }
        
        public bool CanDrop(InventoryItemEntry item) => _floppy.IsFloppy(item.Config);
        public void OnDrop(InventoryItemEntry item)
        {
            _inventory.RemoveItem(item);
            _floppy.Enter(item.Config);
            _afterDrop.Trigger(SubtitlesService);
        }
    }
}