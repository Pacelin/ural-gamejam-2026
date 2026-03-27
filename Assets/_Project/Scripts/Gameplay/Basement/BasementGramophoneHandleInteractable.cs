using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneHandleInteractable : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;
        
        [SerializeField] private BasementGramophoneVelocity _velocity;
        [SerializeField] private float _rotateOnAngles;
        
        protected override void OnInteract()
        {
            _velocity.PerformRotation(_rotateOnAngles);
        }
    }
}