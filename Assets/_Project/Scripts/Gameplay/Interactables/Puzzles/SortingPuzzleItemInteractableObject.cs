using System;
using System.Linq;
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

        [SerializeField] private PuzzleCounter _puzzleCounter;
        [SerializeField] private InventoryItemConfig _correctItem;
        [SerializeField] private string _questionText;
        [Space]
        [SerializeField] private InventoryItemConfig[] _availableItems;
        [SerializeField] private GameObject[] _itemObjectMap;
        [SerializeField] private InventoryItemConfig _initialItem;
        [Space]
        [SerializeField] private PropsEvents _onPut;
        [SerializeField] private PropsEvents _onTake;
        [SerializeField] private PropsEvents _onComplete;
        
        private InventoryModel _inventory;
        private SubtitlesService _subtitles;
        private InventoryItemConfig _currentItem;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _inventory = resolver.Resolve<InventoryModel>();
            _subtitles = resolver.Resolve<SubtitlesService>();
            if (_initialItem)
            {
                _currentItem = _initialItem;
                _onTake.Prepare();
            }
            else
            {
                _onPut.Prepare();
            }
            UpdateItemsActivation();
        }
        
        protected override void OnInteract()
        {
            if (_currentItem)
            {
                if (_currentItem == _correctItem)
                    _puzzleCounter.SetIncorrect();
                
                _inventory.AddItem(_currentItem);
                _currentItem.PickupSound.PlayOneShotInPoint(transform.position);
                _currentItem = null;
                _onTake.Trigger();
                OnChanged?.Invoke(this);
                UpdateItemsActivation();
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
            _currentItem.PutSound.PlayOneShotInPoint(transform.position);
            _inventory.RemoveItem(item);
            _onPut.Trigger();
            OnChanged?.Invoke(this);
            UpdateCursor();
            UpdateItemsActivation();

            if (_currentItem == _correctItem)
            {
                _puzzleCounter.SetCorrect();
                _onComplete.Trigger();
            }
        }

        private void UpdateItemsActivation()
        {
            if (!_currentItem)
            {
                foreach (var obj in _itemObjectMap)
                    obj.SetActive(false);
                return;
            }

            var index = Array.IndexOf(_availableItems, _currentItem);
            _itemObjectMap[index].SetActive(true);
        }
    }
}