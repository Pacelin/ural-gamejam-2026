using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsQuestionValve : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private string _text;
        [SerializeField] private SoundEvent _openSound;
        [SerializeField] private SoundEvent _closeSound;
        [SerializeField] private Transform _valve;
        [SerializeField] private Transform _openValve;
        [SerializeField] private Transform _closeValve;
        [SerializeField] private float _duration = 0.7f;

        private bool _opened;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _valve.rotation = _closeValve.rotation;
        }

        private void OnDestroy()
        {
            _valve.DOKill();
        }

        protected override void OnInteract()
        {
            SubtitlesService.Show(_text);
            if (_opened)
            {
                _opened = false;
                _closeSound.PlayOneShotInPoint(_valve.position);
                _valve.DORotateQuaternion(_closeValve.rotation, _duration);
            }
            else
            {
                _opened = true;
                _openSound.PlayOneShotInPoint(_valve.position);
                _valve.DORotateQuaternion(_openValve.rotation, _duration);
            }
        }
    }
}