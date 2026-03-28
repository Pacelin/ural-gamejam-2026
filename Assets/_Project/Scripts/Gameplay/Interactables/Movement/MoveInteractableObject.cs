using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class MoveInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => _movementService.MovementEnabled ? 
            ECursorState.HoverWalkObject : ECursorState.None;
        protected override ECursorState DownCursorState => _movementService.MovementEnabled ?
            ECursorState.HoverWalkObject : ECursorState.None;

        [SerializeField] private MovementPoint _point;

        private MovementService _movementService;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _movementService = resolver.Resolve<MovementService>();
        }

        private void OnEnable()
        {
            _movementService.OnMovementAvailabilityChanged += UpdateCursor;
        }

        protected override void OnDisable()
        {
            _movementService.OnMovementAvailabilityChanged -= UpdateCursor;
            base.OnDisable();
        }

        protected override void OnInteract()
        {
            if (_movementService.MovementEnabled)
                _movementService.Move(_point);
        }
    }
}