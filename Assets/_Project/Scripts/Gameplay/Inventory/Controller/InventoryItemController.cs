using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Inventory
{
    public class InventoryItemController : System.IDisposable
    {
        public InventoryItemEntry Item => _item;
        
        private readonly InventoryItemEntry _item;
        private readonly InventoryView _view;
        private readonly InventoryItemView _itemView;
        private readonly InventoryItemDragController _itemDragController;
        
        public InventoryItemController(InventoryItemEntry item, 
             InventoryView view, InventoryItemView itemView, InventoryDragController dragController)
        {
            _item = item;
            _view = view;
            _itemView = itemView;
            _itemDragController = new InventoryItemDragController(item, itemView, dragController);
        }

        public void Initialize()
        {            
            _itemView.SetIcon(_item.Icon);
            _itemView.OnPointerEnterEvent += OnEnterItem;
            _itemView.OnPointerExitEvent += OnExitItem;
            
            _itemDragController.Initialize();
        }
        
        public void Dispose()
        {
            _itemView.OnPointerEnterEvent -= OnEnterItem;
            _itemView.OnPointerExitEvent -= OnExitItem;
            
            _itemDragController.Dispose();
        }

        public void DestroyItem() => Object.Destroy(_view.gameObject);
        
        private void OnExitItem(PointerEventData eventData)
        {
            _view.SetTextActive(false);
        }

        private void OnEnterItem(PointerEventData eventData)
        {
            _view.SetTextActive(true);
            _view.SetText(_item.Text);
        }
    }
}