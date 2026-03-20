using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsDoorLockedInteractableObject : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        protected override ECursorState HoverCursorState
        {
            get
            {
                if (_unlocking)
                    return ECursorState.None;
                if (_unlocked)
                    return ECursorState.HoverPointer;
                return ECursorState.HoverQuestion;
            }
        }
        
        protected override ECursorState DownCursorState
        {
            get
            {
                if (_unlocking)
                    return ECursorState.None;
                if (_unlocked)
                    return ECursorState.DownPointer;
                return ECursorState.HoverQuestion;
            }
        }

        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _closedPoint;
        [SerializeField] private Transform _openedPoint;
        [SerializeField] private SoundEvent _openSound;
        [SerializeField] private SoundEvent _closeSound;
        [SerializeField] private float _openCloseDuration = 0.4f;
        [Space]
        [SerializeField] private InventoryItemConfig _key;
        [SerializeField] private SoundEvent _unlockSound;
        [SerializeField] private SoundEvent _lockedSound;
        [SerializeField] private string _text;
        
        private bool _opened;
        private bool _unlocked;
        private bool _unlocking;
        private SubtitlesService _subtitlesService;
        private InventoryModel _inventory;
        
        private void OnDestroy() => _doorOrigin.DOKill();
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _subtitlesService = resolver.Resolve<SubtitlesService>();
            _inventory = resolver.Resolve<InventoryModel>();
        }

        protected override void OnInteract()
        {
            if (_unlocking)
                return;
            if (_unlocked)
            {
                DOTween.Kill(_doorOrigin);
                if (_opened)
                {
                    _opened = false;
                    _doorOrigin.DORotateQuaternion(_closedPoint.rotation, _openCloseDuration);
                    _doorOrigin.DOMove(_closedPoint.position, _openCloseDuration);
                    _closeSound.PlayOneShotInPoint(_doorOrigin.position);
                }
                else
                {
                    _opened = true;
                    _doorOrigin.DORotateQuaternion(_openedPoint.rotation, _openCloseDuration);
                    _doorOrigin.DOMove(_openedPoint.position, _openCloseDuration);
                    _openSound.PlayOneShotInPoint(_doorOrigin.position);
                }
            }
            else
            {
                _lockedSound.PlayOneShotInPoint(_doorOrigin.position);
                _subtitlesService.Show(_text);
            }
        }
        
        public bool CanDrop(InventoryItemEntry item)
        {
            return !_unlocked && !_unlocking && item.Config == _key;
        }

        public void OnDrop(InventoryItemEntry item)
        {
            _unlockSound.PlayOneShotInPoint(_doorOrigin.position);
            _inventory.RemoveItem(item);
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _unlocking = true;
                UpdateCursor();
                
                await UniTask.Delay(TimeSpan.FromSeconds(0.3f), cancellationToken: cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                
                _unlocking = false;
                _unlocked = true;
                UpdateCursor();
            }, this.GetCancellationTokenOnDestroy());
        }
    }
}