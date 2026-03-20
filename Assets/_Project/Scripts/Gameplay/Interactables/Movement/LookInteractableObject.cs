using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class LookInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.Eye;
        protected override ECursorState DownCursorState => ECursorState.Eye;

        [SerializeField] private MovementPoint _point;

        private MovementService _movementService;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _movementService = resolver.Resolve<MovementService>();
        }

        protected override void OnInteract()
        {
            _movementService.Move(_point, false);
        }
    }
}