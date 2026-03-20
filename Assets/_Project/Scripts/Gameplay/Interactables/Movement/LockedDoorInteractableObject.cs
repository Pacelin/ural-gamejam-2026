using System;
using Cysharp.Threading.Tasks;
using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class LockedDoorInteractableObject : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverWalkObject;
        protected override ECursorState DownCursorState => ECursorState.HoverWalkObject;
        
        private bool _unlocked;
        
        [SerializeField] private MovementPoint _point;
        [SerializeField] private Transform _door;
        [SerializeField] private InventoryItemConfig _key;
        [SerializeField] private SoundEvent _moveSound;
        [SerializeField] private SoundEvent _closedSound;
        [SerializeField] private SoundEvent _unlockSound;

        private MovementService _movementService;
        private SubtitlesService _subtitlesService;
        private InventoryModel _inventory;

        private void OnDrawGizmosSelected()
        {
            if (_point)
            {
                Gizmos.color = Color.magenta;
                var t = _point.transform;
                var p = t.position;
                Gizmos.DrawSphere(p + t.forward / 2, 0.3f);
            }
        }

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _movementService = resolver.Resolve<MovementService>();
            _subtitlesService = resolver.Resolve<SubtitlesService>();
            _inventory = resolver.Resolve<InventoryModel>();
        }

        protected override void OnInteract()
        {
            if (_unlocked)
            {
                _movementService.MoveInDoor(_point, _door.position, _moveSound);
            }
            else
            {
                _closedSound.PlayOneShotInPoint(_door.position);
                _subtitlesService.Show("Закрыто");
            }
        }

        public bool CanDrop(InventoryItemEntry item)
        {
            return !_unlocked && item.Config == _key;
        }

        public void OnDrop(InventoryItemEntry item)
        {
            _unlockSound.PlayOneShotInPoint(_door.position);
            _inventory.RemoveItem(item);
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _movementService.BlockControls();
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                _movementService.UnblockControls();
                _unlocked = true;
            }, this.GetCancellationTokenOnDestroy());
        }
    }
}