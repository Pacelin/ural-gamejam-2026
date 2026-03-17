using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Gameplay.Inventory
{
    public class InventoryItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, 
        IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event System.Action<PointerEventData> OnPointerEnterEvent; 
        public event System.Action<PointerEventData> OnPointerExitEvent; 
        public event System.Action<PointerEventData> OnPointerDownEvent;
        public event System.Action<PointerEventData> OnPointerUpEvent;
        public event System.Action<PointerEventData> OnDragEvent;

        [SerializeField] private Image _icon;
        
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        public void SetVisible(bool isVisible) => _icon.enabled = isVisible;

        private void OnDestroy() => _icon.rectTransform.DOKill();

        public void Impact()
        {
            _icon.rectTransform.DOKill(true);
            _icon.rectTransform.DOShakeRotation(0.6f, Vector3.forward * 5f);
        } 

        public void OnPointerEnter(PointerEventData eventData) => OnPointerEnterEvent?.Invoke(eventData);
        public void OnPointerExit(PointerEventData eventData) => OnPointerExitEvent?.Invoke(eventData);
        public void OnPointerDown(PointerEventData eventData) => OnPointerDownEvent?.Invoke(eventData);
        public void OnPointerUp(PointerEventData eventData) => OnPointerUpEvent?.Invoke(eventData);
        public void OnDrag(PointerEventData eventData) => OnDragEvent?.Invoke(eventData);
    }
}