using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Gameplay.Inventory
{
    public class InventoryItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public event System.Action<InventoryItemView> OnPointerEnterEvent; 
        public event System.Action<InventoryItemView> OnPointerExitEvent; 
        public event System.Action<InventoryItemView> OnPointerClickEvent;
        
        [SerializeField] private Image _icon;
        [SerializeField] private UIEffect _selectedEffect;
        
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        public void SetSelected(bool selected) => _selectedEffect.enabled = selected;

        public void OnPointerEnter(PointerEventData eventData) => OnPointerEnterEvent?.Invoke(this);
        public void OnPointerExit(PointerEventData eventData) => OnPointerExitEvent?.Invoke(this);
        public void OnPointerClick(PointerEventData eventData) => OnPointerClickEvent?.Invoke(this);
    }
}