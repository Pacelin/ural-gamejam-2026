using System;
using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsDoor : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _openedPoint;
        [SerializeField] private Transform _closedPoint;
        [SerializeField] private SoundEvent _openSound;
        [SerializeField] private SoundEvent _closeSound;
        [SerializeField] private float _openCloseDuration = 0.4f;
        [Space]
        [SerializeField] private PropsEvents _onOpen;
        [SerializeField] private PropsEvents _onClose;
        [Space]
        [SerializeField] private bool _useOtherCloseDuration = false;
        [SerializeField] private float _otherCloseDuration;
        [SerializeField] private bool _useCustomEaseOnClose = false;
        [SerializeField] private Ease _customEase = Ease.OutBounce;
        
        private bool _opened;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _onOpen.Prepare();
        }

        private void OnDestroy() => _doorOrigin.DOKill();
        
        protected override void OnInteract()
        {
            DOTween.Kill(_doorOrigin);
            if (_opened)
            {
                _opened = false;
                var duration = _useOtherCloseDuration ? _otherCloseDuration : _openCloseDuration;
                var ease = _useCustomEaseOnClose ? _customEase : Ease.InQuad;
                DOTween.Sequence(_doorOrigin)
                    .Append(_doorOrigin.DORotateQuaternion(_closedPoint.rotation, duration)
                        .SetEase(ease))
                    .Join(_doorOrigin.DOMove(_closedPoint.position, duration)
                        .SetEase(ease))
                    .AppendCallback(() => _onClose.Trigger());
                _closeSound.PlayOneShotInPoint(_doorOrigin.position);
            }
            else
            {
                _opened = true;
                DOTween.Sequence(_doorOrigin)
                    .AppendCallback(() => _onOpen.Trigger())
                    .Append(_doorOrigin.DORotateQuaternion(_openedPoint.rotation, _openCloseDuration))
                    .Join(_doorOrigin.DOMove(_openedPoint.position, _openCloseDuration));
                _openSound.PlayOneShotInPoint(_doorOrigin.position);
            }
        }
    }
}