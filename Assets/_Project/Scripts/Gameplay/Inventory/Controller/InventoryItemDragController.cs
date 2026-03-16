using UnityEngine.EventSystems;

namespace Project.Gameplay.Inventory
{
    public class InventoryItemDragController : System.IDisposable
    {
        private readonly InventoryItemEntry _item;
        private readonly InventoryItemView _itemView;
        private readonly InventoryDragController _dragController;
        
        public InventoryItemDragController(InventoryItemEntry item, InventoryItemView itemView, InventoryDragController dragController)
        {
            _item = item;
            _itemView = itemView;
            _dragController = dragController;
        }

        public void Initialize()
        {            
            _itemView.SetVisible(true);
            _itemView.OnPointerEnterEvent += OnPointerEnter;
            _itemView.OnPointerExitEvent += OnPointerExit;
            _itemView.OnPointerDownEvent += OnPointerDown;
            _itemView.OnPointerUpEvent += OnPointerUp;
            _itemView.OnDragEvent += OnDrag;
        }

        public void Dispose()
        {
            _itemView.OnPointerEnterEvent -= OnPointerEnter;
            _itemView.OnPointerExitEvent -= OnPointerExit;
            _itemView.OnPointerDownEvent -= OnPointerDown;
            _itemView.OnPointerUpEvent -= OnPointerUp;
            _itemView.OnDragEvent -= OnDrag;
        }

        private void OnPointerEnter(PointerEventData eventData) => _dragController.OnItemEnter();
        private void OnPointerExit(PointerEventData eventData) => _dragController.OnItemExit();
        private void OnPointerDown(PointerEventData eventData) => _dragController.OnBeginDrag(_itemView, _item, eventData);
        private void OnPointerUp(PointerEventData eventData) => _dragController.OnEndDrag(eventData);
        private void OnDrag(PointerEventData eventData) => _dragController.OnDrag(eventData);
    }
}