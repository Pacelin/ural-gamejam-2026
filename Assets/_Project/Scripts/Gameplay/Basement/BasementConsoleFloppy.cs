using System.Linq;
using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Inventory;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleFloppy : MonoBehaviour
    {
        public InventoryItemConfig FloppyItem => _item;
        
        [SerializeField] private BasementConsoleScreens _consoleScreens;
        [SerializeField] private BasementConsoleFloppyEjectButton _ejectButton;
        [SerializeField] private GameObject _pickupActivator;
        [Space]
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _enterSound;
        [SerializeField] private SoundEvent _exitSound;
        [SerializeField] private float _enterDuration;
        [SerializeField] private float _exitDuration;
        [Space]
        [SerializeField] private InventoryItemConfig[] _items;
        [SerializeField] private GameObject[] _floppies;

        private InventoryItemConfig _item;
        private static readonly int ENTER_TRIGGER = Animator.StringToHash("enter");
        private static readonly int EXIT_TRIGGER = Animator.StringToHash("exit");

        public bool IsFloppy(InventoryItemConfig item) => _items.Contains(item);
        
        public void Enter(InventoryItemConfig floppyItem)
        {
            var itemIndex = System.Array.IndexOf(_items, floppyItem);
            
            _floppies[itemIndex].SetActive(true);
            _animator.SetTrigger(ENTER_TRIGGER);
            _enterSound.PlayOneShotInPoint(_soundPoint.position);
            
            DOVirtual.DelayedCall(_enterDuration, () =>
            {
                _item = floppyItem;
                _consoleScreens.InsertDisk(floppyItem);
                _ejectButton.SetBlock(false);
            }).SetTarget(this);
        }

        public void Eject()
        {
            _animator.SetTrigger(EXIT_TRIGGER);
            _exitSound.PlayOneShotInPoint(_soundPoint.position);
            _ejectButton.SetBlock(true);
            _consoleScreens.ClearDisk();

            DOVirtual.DelayedCall(_exitDuration, () =>
            {
                _pickupActivator.SetActive(true);
            });
        }
    }
}