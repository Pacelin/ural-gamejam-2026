using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace Project.Gameplay.Inventory
{
    public class InventoryController : IInitializable, System.IDisposable
    {
        private readonly InventoryView _view;
        private readonly InventoryModel _model;
        private readonly List<InventoryItemView> _items;
        
        public InventoryController(InventoryView view, InventoryModel model)
        {
            _view = view;
            _model = model;
            _items = new List<InventoryItemView>();
        }
        
        public void Initialize()
        {
            _model.OnAddItem += OnAddItem;
            _model.OnRemoveItem += OnRemoveItem;
            _model.OnSelectionChanged += OnSelectionChanged;
            
            for (int i = 0; i < _model.Items.Count; i++)
                OnAddItem(i);
        }

        public void Dispose()
        {
            _model.OnAddItem -= OnAddItem;
            _model.OnRemoveItem -= OnRemoveItem;
            _model.OnSelectionChanged -= OnSelectionChanged;
            
            foreach (var item in _items)
            {
                item.OnPointerClickEvent -= OnClickItem;
                item.OnPointerEnterEvent -= OnEnterItem;
                item.OnPointerExitEvent -= OnExitItem;
            }
        }

        private void OnSelectionChanged(int prevIndex, int nextIndex)
        {
            if (prevIndex != -1)
            {
                _items[prevIndex].SetSelected(false);
                _view.SetTextActive(false);
            }
            
            if (nextIndex != -1)
            {
                _items[nextIndex].SetSelected(true);
                _view.SetTextActive(true);
                _view.SetText(_model.Items[nextIndex].Text);
            }
        }

        private void OnAddItem(int index)
        {
            var itemConfig = _model.Items[index];
            var item = _view.CreateItem();
            item.SetIcon(itemConfig.Icon);
            item.SetSelected(false);
            _items.Add(item);
            
            item.OnPointerClickEvent += OnClickItem;
            item.OnPointerEnterEvent += OnEnterItem;
            item.OnPointerExitEvent += OnExitItem;
        }

        private void OnRemoveItem(int index)
        {
            var item = _items[index];
            
            item.OnPointerClickEvent -= OnClickItem;
            item.OnPointerEnterEvent -= OnEnterItem;
            item.OnPointerExitEvent -= OnExitItem;
            
            Object.Destroy(item.gameObject);
            _items.RemoveAt(index);
        }

        private void OnExitItem(InventoryItemView item)
        {
            _view.SetTextActive(false);
            if (_model.SelectedIndex != -1)
            {
                _view.SetTextActive(true);
                _view.SetText(_model.Items[_model.SelectedIndex].Text);
            }
        }

        private void OnEnterItem(InventoryItemView item)
        {
            _view.SetTextActive(true);
            _view.SetText(_model.Items[_items.IndexOf(item)].Text);
        }

        private void OnClickItem(InventoryItemView item)
        {
            _model.SetSelected(_items.IndexOf(item));
        }
    }
}