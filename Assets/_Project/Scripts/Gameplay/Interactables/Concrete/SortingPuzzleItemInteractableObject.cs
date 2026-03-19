using System;
using System.Linq;
using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class SortingPuzzleItemInteractableObject : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        public event Action<SortingPuzzleItemInteractableObject> OnChanged;
        public bool IsComplete => _currentItem == _correctItem;
        
        protected override ECursorState HoverCursorState =>
            _currentItem ? ECursorState.HoverPickup : ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState =>
            _currentItem ? ECursorState.HoverPickup : ECursorState.HoverQuestion;
        
        [SerializeField] private InventoryItemConfig _correctItem;
        [SerializeField] private string _questionText;
        [Space]
        [SerializeField] private InventoryItemConfig[] _availableItems;
        [SerializeField] private GameObject[] _itemObjectMap;
        [SerializeField] private GameObject _emptyObject;
        [SerializeField] private SoundEvent _pickupSound;
        [SerializeField] private SoundEvent _dropSound;
        
        private InventoryModel _inventory;
        private SubtitlesService _subtitles;
        private InventoryItemConfig _currentItem;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _inventory = resolver.Resolve<InventoryModel>();
            _subtitles = resolver.Resolve<SubtitlesService>();
        }
        
        protected override void OnInteract()
        {
            if (_currentItem)
            {
                _inventory.AddItem(_currentItem);
                _pickupSound.PlayOneShotInPoint(transform.position);
                _currentItem = null;
                OnChanged?.Invoke(this);
                UpdateState();
            }
            else
            {
                _subtitles.Show(_questionText);
            }
        }
        
        public bool CanDrop(InventoryItemEntry item)
        {
            if (_currentItem)
                return false;
            if (_availableItems.Any(i => item.Config == i))
                return true;
            return false;
        }

        public void OnDrop(InventoryItemEntry item)
        {
            _currentItem = item.Config;
            _dropSound.PlayOneShotInPoint(transform.position);
            _inventory.RemoveItem(item);
            OnChanged?.Invoke(this);
            UpdateCursor();
            UpdateState();
        }

        private void UpdateState()
        {
            if (!_currentItem)
            {
                foreach (var obj in _itemObjectMap)
                    obj.SetActive(false);
                if (_emptyObject)
                    _emptyObject.SetActive(true);
                return;
            }

            var index = Array.IndexOf(_availableItems, _currentItem);
            _emptyObject.SetActive(false);
            _itemObjectMap[index].SetActive(true);
        }
    }
}