using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Interactables.Intro
{
    public class IntroEnvelopeInteractable : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private IntroEnvelopeAnimatorHandler _animatorHandler;
        
        protected override void OnInteract()
        {
            _animatorHandler.Open();
            Destroy(gameObject);
        }
    }
}