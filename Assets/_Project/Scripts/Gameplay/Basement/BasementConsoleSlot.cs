using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Interactables;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleSlot : NotInteractableObject
    {
        [SerializeField] private Transform _transform;
        [Space]
        [SerializeField] private Vector3 _closeRotation;
        [SerializeField] private Vector3 _openRotation;
        [Space]
        [SerializeField] private float _openDuration;
        [SerializeField] private float _closeDuration;
        [SerializeField] private Ease _openEase;
        [SerializeField] private Ease _closeEase;
        [Space]
        [SerializeField] private PropsEvents _onOpen;
        [SerializeField] private PropsEvents _onClose;
        [Space]
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _closeSound;
        [SerializeField] private SoundEvent _openSound;

        private bool _opened;
        
        protected override void Initialize(IObjectResolver resolver) { }
        
        private void OnDestroy()
        {
            DOTween.Kill(_transform);
        }

        public void Open()
        {
            if (_opened)
                return;

            _openSound.PlayOneShotInPoint(_soundPoint.position);
            _opened = true;
            DOTween.Sequence(_transform)
                .AppendCallback(() => _onOpen.Trigger(SubtitlesService))
                .Append(_transform.DORotate(_openRotation, _openDuration).SetEase(_openEase));
        }

        public void Close()
        {
            if (!_opened)
                return;

            _closeSound.PlayOneShotInPoint(_soundPoint.position);
            _opened = false;
            DOTween.Sequence(_transform)
                .Append(_transform.DORotate(_closeRotation, _closeDuration).SetEase(_closeEase))
                .AppendCallback(() => _onClose.Trigger(SubtitlesService));
        }
    }
}