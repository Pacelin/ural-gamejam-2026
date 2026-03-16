using UnityEngine;

namespace Project.Gameplay.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Create Item Config")]
    public class InventoryItemConfig : ScriptableObject
    {
        public Sprite Icon => _icon;
        public string Text => _text;
        
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _text;
    }
}