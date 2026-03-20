using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PuzzleWithInventoryInteractableObject : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        protected override ECursorState HoverCursorState
        {
            get
            {
                if (_solved)
                    return ECursorState.None;
                return ECursorState.HoverQuestion;
            }
        }
        
        protected override ECursorState DownCursorState
        {
            get
            {
                if (_solved)
                    return ECursorState.None;
                return ECursorState.HoverQuestion;
            }
        }

        [SerializeField] private InventoryItemConfig _key;
        [SerializeField] private string _text;
        [SerializeField] private SoundEvent _dropSound;
        [SerializeField] private PuzzleTrigger _trigger;
        
        private bool _solved;
        private SubtitlesService _subtitlesService;
        private InventoryModel _inventory;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _subtitlesService = resolver.Resolve<SubtitlesService>();
            _inventory = resolver.Resolve<InventoryModel>();
        }

        protected override void OnInteract()
        {
            if (_solved)
                return;
            
            _subtitlesService.Show(_text);
        }
        
        public bool CanDrop(InventoryItemEntry item)
        {
            return !_solved && item.Config == _key;
        }

        public void OnDrop(InventoryItemEntry item)
        {
            _dropSound.PlayOneShot();
            _inventory.RemoveItem(item);
            UpdateCursor();
            _trigger.OnComplete();
        }
    }
}