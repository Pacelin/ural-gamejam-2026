using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Create Item Config")]
    public class InventoryItemConfig : ScriptableObject
    {
        public Sprite Icon => _icon;
        public string Text => _text;
        public SoundEvent PickupSound => _pickupSound;
        public SoundEvent PutSound => _putSound;
        
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _text;
        [SerializeField] private SoundEvent _pickupSound;
        [SerializeField] private SoundEvent _putSound;
    }
}