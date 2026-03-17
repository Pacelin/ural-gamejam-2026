using System.Collections.Generic;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Inventory
{
    public class InventoryDragController : System.IDisposable
    {
        private bool _isDragging;
        private InventoryItemEntry _draggingItem;
        private RectTransform _draggingItemTransform;
        private InventoryItemView _draggingItemView;
        private Vector2 _dragOffset;
        private Vector2 _eventPointPosition;
        
        private readonly InventoryDragView _dragView;
        private readonly RectTransform _dragViewTransform;
        private readonly RectTransform _dragViewParentTransform;
        private readonly InventoryTextController _textController;
        private readonly CursorService _cursorService;
        
        public InventoryDragController(InventoryDragView dragView, InventoryTextController textController,
            CursorService cursorService)
        {
            _dragView = dragView;
            _textController = textController;
            _cursorService = cursorService;
            
            _dragViewTransform = _dragView.transform as RectTransform;
            _dragViewParentTransform = _dragViewTransform!.parent as RectTransform;
            _dragView.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            _dragView.OnUpdate += OnUpdate;
        }
        
        public void Dispose()
        {
            _dragView.OnUpdate -= OnUpdate;
        }

        public void OnBeginDrag(InventoryItemView itemView, InventoryItemEntry item, PointerEventData eventData)
        {
            if (_isDragging)
                return;

            itemView.SetVisible(false);
            _isDragging = true;
            
            _draggingItem = item;
            _draggingItemView = itemView;
            _draggingItemTransform = (RectTransform) itemView.transform;

            _dragView.SetImage(_draggingItem.Icon);
            _dragView.gameObject.SetActive(true);

            var itemScreenPoint = RectTransformUtility.WorldToScreenPoint(_dragView.Canvas.worldCamera, 
                _draggingItemTransform.position);

            _dragOffset = eventData.position - itemScreenPoint;
            _eventPointPosition = eventData.position;
            UpdatePosition();
            _textController.SetHold(_draggingItem);
            _cursorService.EnableCursorState(ECursorState.HoldInventoryItem);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDragging)
                return;
            
            _eventPointPosition = eventData.position;
            UpdatePosition();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!_isDragging)
                return;

            _dragView.gameObject.SetActive(false);
            _draggingItemView.SetVisible(true);
            
            var dropTarget = FindDropTarget(eventData);
            if (dropTarget != null && dropTarget.CanDrop(_draggingItem))
                dropTarget.OnDrop(_draggingItem);

            _draggingItem = null;
            _draggingItemView = null;
            _draggingItemTransform = null;
            _isDragging = false;
            _textController.SetHold(null);
            _cursorService.DisableCursorState(ECursorState.HoldInventoryItem);
        }

        private void OnUpdate()
        {
            if (!_isDragging)
                return;

            if (_dragOffset == Vector2.zero)
                return;

            _dragOffset = Vector2.MoveTowards(_dragOffset, Vector2.zero, _dragView.CentricSpeed * Time.deltaTime);
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            var targetScreenPosition = _eventPointPosition - _dragOffset;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_dragViewParentTransform,
                    targetScreenPosition, _dragView.Canvas.worldCamera, out var localPoint))
            {
                _dragViewTransform.anchoredPosition = localPoint;
            }
        }
        
        private IInventoryItemDropTarget FindDropTarget(PointerEventData eventData)
        {
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            foreach (var result in results)
            {
                var target = result.gameObject.GetComponentInParent<IInventoryItemDropTarget>();
                if (target != null)
                    return target;
            }
            return null;
        }

        public void OnItemEnter() => _cursorService.EnableCursorState(ECursorState.HoverInventoryItem);
        public void OnItemExit() => _cursorService.DisableCursorState(ECursorState.HoverInventoryItem);
    }
}