using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGeneratorDoor : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _openPoint;
        [SerializeField] private SoundEvent _openSound;
        [SerializeField] private float _openDuration = 2f;
        [SerializeField] private float _triggerDuraction = 3f;
        [SerializeField] private Ease _openEase = Ease.InQuad;
        [SerializeField] private PropsEvents _onOpenStart;
        [SerializeField] private PropsEvents _onTrigger;
        [SerializeField] private PropsEvents _onOpenEnd;
        
        private void OnDestroy()
        {
            DOTween.Kill(_doorOrigin);
        }

        protected override void OnInteract()
        {
            _onOpenStart.Trigger(SubtitlesService);
            _openSound.PlayOneShotInPoint(_doorOrigin.position);
            DOVirtual.DelayedCall(_triggerDuraction, () => _onTrigger.Trigger(SubtitlesService))
                .SetTarget(_doorOrigin);
            _doorOrigin.DORotateQuaternion(_openPoint.rotation, _openDuration)
                .SetEase(_openEase)
                .OnComplete(() => _onOpenEnd.Trigger(SubtitlesService));
        }
    }
}