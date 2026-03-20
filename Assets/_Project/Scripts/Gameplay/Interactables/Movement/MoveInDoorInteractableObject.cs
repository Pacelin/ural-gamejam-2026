using Plugins.Audio;
using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class MoveInDoorInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverWalkObject;
        protected override ECursorState DownCursorState => ECursorState.HoverWalkObject;

        [SerializeField] private MovementPoint _point;
        [SerializeField] private Transform _door;
        [SerializeField] private SoundEvent _moveSound;

        private MovementService _movementService;
        
        private void OnDrawGizmosSelected()
        {
            if (_point)
            {
                Gizmos.color = Color.magenta;
                var t = _point.transform;
                var p = t.position;
                Gizmos.DrawSphere(p + t.forward / 2, 0.2f);
            }
        }
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _movementService = resolver.Resolve<MovementService>();
        }

        protected override void OnInteract()
        {
            _movementService.MoveInDoor(_point, _door.position, _moveSound);
        }
    }
}