using DG.Tweening;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class ChiffonerDoorInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _closedPoint;
        [SerializeField] private Transform _openedPoint;
        
        private bool _opened;
        
        protected override void OnInteract()
        {
            DOTween.Kill(_doorOrigin);
            if (_opened)
            {
                _opened = false;
                _doorOrigin.DORotateQuaternion(_closedPoint.rotation, 0.4f);
            }
            else
            {
                _opened = true;
                _doorOrigin.DORotateQuaternion(_openedPoint.rotation, 0.4f);
            }
        }
    }
}