using System;
using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneSlot : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        public int InsertedIndex => _insertedItem ? Array.IndexOf(_items, _insertedItem) : -1;
        
        protected override ECursorState HoverCursorState =>
            _insertedItem ? ECursorState.HoverPickup : ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState =>
            _insertedItem ? ECursorState.HoverPickup : ECursorState.HoverQuestion;
        
        [SerializeField] private InventoryItemConfig[] _items;
        [SerializeField] private GameObject[] _pickups;
        [SerializeField] private string _askString;

        private InventoryModel _inventory;
        private InventoryItemConfig _insertedItem;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _inventory = resolver.Resolve<InventoryModel>();
        }

        protected override void OnInteract()
        {
            if (_insertedItem)
            {
                var index = Array.IndexOf(_items, _insertedItem);
                _pickups[index].SetActive(false);
                _insertedItem.PickupSound.PlayOneShotInPoint(transform.position);
                _inventory.AddItem(_insertedItem);
                _insertedItem = null;
                UpdateCursor();
            }
            else
            {
                SubtitlesService.Show(_askString);
            }
        }

        public bool CanDrop(InventoryItemEntry item) => _insertedItem == null;
        public void OnDrop(InventoryItemEntry item)
        {
            item.Config.PutSound.PlayOneShotInPoint(transform.position);
            _inventory.RemoveItem(item);

            _insertedItem = item.Config;
            var index = Array.IndexOf(_items, _insertedItem);
            _pickups[index].SetActive(true);
            UpdateCursor();
        }
    }
}