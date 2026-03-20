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
                DOTween.Sequence(_doorOrigin)
                    .Append(_doorOrigin.DORotateQuaternion(_closedPoint.rotation, _openCloseDuration))
                    .Join(_doorOrigin.DOMove(_closedPoint.position, _openCloseDuration))
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