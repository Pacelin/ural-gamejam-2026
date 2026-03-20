using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PropsDoorInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _closedPoint;
        [SerializeField] private Transform _openedPoint;
        [SerializeField] private SoundEvent _openSound;
        [SerializeField] private SoundEvent _closeSound;
        [SerializeField] private float _openCloseDuration = 0.4f;
        
        private bool _opened;
        
        protected override void OnInteract()
        {
            DOTween.Kill(_doorOrigin);
            if (_opened)
            {
                _opened = false;
                _doorOrigin.DORotateQuaternion(_closedPoint.rotation, _openCloseDuration);
                _closeSound.PlayOneShotInPoint(_doorOrigin.position);
            }
            else
            {
                _opened = true;
                _doorOrigin.DORotateQuaternion(_openedPoint.rotation, _openCloseDuration);
                _openSound.PlayOneShotInPoint(_doorOrigin.position);
            }
        }
    }
}