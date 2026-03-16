using TMPro;
using UnityEngine;

namespace Project.Gameplay.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public InventoryDragView DragView => _dragView;
        
        [SerializeField] private InventoryDragView _dragView;
        [SerializeField] private RectTransform _itemsContainer;
        [SerializeField] private InventoryItemView _itemPrefab;
        [SerializeField] private TMP_Text _text;

        public void SetTextActive(bool isActive) => _text.gameObject.SetActive(isActive);
        public void SetText(string text) => _text.text = text;

        public InventoryItemView CreateItem() => Instantiate(_itemPrefab, _itemsContainer);
    }
}