using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class MoveInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverWalkObject;
        protected override ECursorState DownCursorState => ECursorState.None;

        [SerializeField] private MovementPoint _point;

        private MovementService _movementService;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _movementService = resolver.Resolve<MovementService>();
        }

        protected override void OnInteract()
        {
            _movementService.Move(_point);
        }
    }
}