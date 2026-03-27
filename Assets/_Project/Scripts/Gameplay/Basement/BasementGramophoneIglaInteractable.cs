using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneIglaInteractable : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;
        
        [SerializeField] private BasementGramophoneIgla _igla;
        
        protected override void OnInteract()
        {
            _igla.Switch();
        }
    }
}