using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PropsToiletHandle : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;
        
        [SerializeField] private Transform _handle;
        [SerializeField] private Vector3 _defaultRotation;
        [SerializeField] private Vector3 _downRotation;
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private SoundEvent _soundEvent;

        private void OnDestroy()
        {
            DOTween.Kill(_handle);
        }

        protected override void OnInteract()
        {
            DOTween.Kill(_handle);
            _soundEvent.PlayOneShotInPoint(_handle.position);
            DOTween.Sequence(_handle)
                .Append(_handle.DORotate(_downRotation, _fadeInDuration))
                .Append(_handle.DORotate(_defaultRotation, _fadeOutDuration).SetEase(Ease.InQuad));
        }
    }
}