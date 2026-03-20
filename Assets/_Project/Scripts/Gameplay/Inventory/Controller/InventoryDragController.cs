using System.Collections.Generic;
using Plugins.Audio;
using Project.Core.Pause;
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
        private System.IDisposable _pauseDisposable;
        
        private readonly InventoryDragView _dragView;
        private readonly RectTransform _dragViewTransform;
        private readonly RectTransform _dragViewParentTransform;
        private readonly InventoryTextController _textController;
        private readonly CursorService _cursorService;
        private readonly PauseController _pauseController;
        
        public InventoryDragController(InventoryDragView dragView, InventoryTextController textController,
            CursorService cursorService, PauseController pauseController)
        {
            _dragView = dragView;
            _textController = textController;
            _cursorService = cursorService;
            _pauseController = pauseController;
            
            _dragViewTransform = _dragView.transform as RectTransform;
            _dragViewParentTransform = _dragViewTransform!.parent as RectTransform;
            _dragView.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            _dragView.OnUpdate += OnUpdate;
            _pauseDisposable = _pauseController.SubscribeAnyPause(isPause =>
            {
                if (isPause)
                    StopDrag();
            });
        }
        
        public void Dispose()
        {
            _dragView.OnUpdate -= OnUpdate;
            _pauseDisposable.Dispose();
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

            _dragOffset = eventData.position - eventData.position;
            _eventPointPosition = eventData.position;
            
            UpdatePosition();
            _textController.SetHold(_draggingItem);
            _cursorService.EnableCursorState(ECursorState.HoldInventoryItem);
            AudioSystem.Game_Misc_GrabInventory.PlayOneShot();
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
            _draggingItemView.Impact();
            
            var dropTarget = FindDropTarget(eventData);
            if (dropTarget != null && dropTarget.CanDrop(_draggingItem))
                dropTarget.OnDrop(_draggingItem);

            _draggingItem = null;
            _draggingItemView = null;
            _draggingItemTransform = null;
            _isDragging = false;
            _textController.SetHold(null);
            _cursorService.DisableCursorState(ECursorState.HoldInventoryItem);
            AudioSystem.Game_Misc_DropInventory.PlayOneShot();
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

        private void StopDrag()
        {
            if (!_isDragging)
                return;

            _dragView.gameObject.SetActive(false);
            _draggingItemView.SetVisible(true);
            
            _draggingItem = null;
            _draggingItemView = null;
            _draggingItemTransform = null;
            _isDragging = false;
            _textController.SetHold(null);
            _cursorService.DisableCursorState(ECursorState.HoldInventoryItem);
        }

        private void UpdatePosition()
        {
            var targetScreenPosition = _eventPointPosition - _dragOffset;
            _dragViewTransform.position = targetScreenPosition;
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