using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsDropWithQuestion : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState => ECursorState.HoverQuestion;
        
        [SerializeField] private InventoryItemConfig _requireItem;
        [SerializeField] private string _text;
        [SerializeField] private bool _playSoundOnQuestion;
        [SerializeField] private SoundEvent _sound;
        [SerializeField] private PropsEvents _afterDrop;

        private InventoryModel _inventory;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _inventory = resolver.Resolve<InventoryModel>();
            _afterDrop.Prepare();
        }

        protected override void OnInteract()
        {
            if (_playSoundOnQuestion)
                _sound.PlayOneShotInPoint(transform.position);
            SubtitlesService.Show(_text);
        }
        
        public bool CanDrop(InventoryItemEntry item) => item.Config == _requireItem;
        public void OnDrop(InventoryItemEntry item)
        {
            item.Config.PutSound.PlayOneShotInPoint(transform.position);
            _inventory.RemoveItem(item);
            _afterDrop.Trigger(SubtitlesService);
        }
    }
}