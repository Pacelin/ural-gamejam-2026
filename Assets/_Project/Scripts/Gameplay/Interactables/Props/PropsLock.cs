using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsLock : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState => ECursorState.HoverQuestion;

        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _openedPoint;
        [SerializeField] private float _openDuration = 0.4f;
        [Space]
        [SerializeField] private SoundEvent _openSound;
        [SerializeField] private SoundEvent _lockedSound;
        [SerializeField] private string _text;
        [Space]
        [SerializeField] private PropsEvents _onUnlock;
        
        private SubtitlesService _subtitlesService;
        
        private void OnDestroy() => _doorOrigin.DOKill();
        
        public void Unlock()
        {
            DOTween.Sequence(_doorOrigin)
                .Append(_doorOrigin.DORotateQuaternion(_openedPoint.rotation, _openDuration))
                .Join(_doorOrigin.DOMove(_openedPoint.position, _openDuration))
                .AppendCallback(() => _onUnlock.Trigger());
            _openSound.PlayOneShotInPoint(_doorOrigin.position);
        }
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _subtitlesService = resolver.Resolve<SubtitlesService>();
            _onUnlock.Prepare();
        }

        protected override void OnInteract()
        {
            DOTween.Kill(_doorOrigin);
            _lockedSound.PlayOneShotInPoint(_doorOrigin.position);
            _subtitlesService.Show(_text);
        }
    }
}