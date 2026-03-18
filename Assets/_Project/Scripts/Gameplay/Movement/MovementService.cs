using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer.Unity;

namespace Project.Gameplay.Movement
{
    [UsedImplicitly]
    public class MovementService : IInitializable, IStartable
    {
        private MovementPoint _activePoint;

        private readonly CursorService _cursorService;
        private readonly MovementBlockView _blockView;
        private readonly MovementControlView _controlView;
        private readonly MovementCameraController _cameraController;
        private readonly MovementConfig _movementConfig;
        
        public MovementService(CursorService cursorService,
            MovementBlockView blockView, MovementControlView controlView,
            MovementCameraController cameraController,
            MovementPoint initialMovementPoint)
        {
            _cursorService = cursorService;
            _blockView = blockView;
            _controlView = controlView;
            _movementConfig = Resources.Load<MovementConfig>("SO_MovementConfig");
            _cameraController = cameraController;
            _activePoint = initialMovementPoint;
        }

        public void Initialize()
        {
            _controlView.Setup(this, _cursorService);
        }

        public void Start()
        {
            foreach (var obj in _activePoint.ActiveWhenOnPoint)
                obj.SetActive(true);
            
            _controlView.UpdateControlsFor(_activePoint);

            var activePointTransform = _activePoint.transform;
            _cameraController.Set(activePointTransform.position, activePointTransform.rotation);
        }

        public void RotateRight() => Move(_activePoint.RightPoint);
        public void RotateLeft() => Move(_activePoint.LeftPoint);
        public void MoveBack() => Move(_activePoint.BackPoint);
        
        public void Move(MovementPoint point)
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _cursorService.EnableCursorState(ECursorState.Transition);
                _blockView.Block();
                
                foreach (var obj in _activePoint.ActiveWhenOnPoint)
                    obj.SetActive(false);
                foreach (var obj in point.ActiveWhenOnPoint)
                    obj.SetActive(true);
                
                _controlView.UpdateControlsFor(point);

                await MoveTo(point, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
                _activePoint = point;
                _blockView.Unblock();
                _cursorService.DisableCursorState(ECursorState.Transition);
            }, _blockView.gameObject.GetCancellationTokenOnDestroy());
        }

        private async UniTask MoveTo(MovementPoint point, CancellationToken cancellationToken)
        {
            var cameraPosition = _cameraController.GetPosition();
            var newPointTransform = point.transform;

            var distance = Vector3.Distance(cameraPosition, newPointTransform.position);
            if (distance > 0.2f)
                AudioSystem.Game_Walk.PlayOneShot();

            var duration = Mathf.Clamp(distance * _movementConfig.MoveDurationPerMeter,
                _movementConfig.MinMoveDuration, _movementConfig.MaxMoveDuration);
            
            await _cameraController.MoveTo(newPointTransform.position, newPointTransform.rotation, duration,
                cancellationToken);
        }
    }
}