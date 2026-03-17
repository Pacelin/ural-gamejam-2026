using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer.Unity;

namespace Project.Gameplay.Movement
{
    [UsedImplicitly]
    public class MovementService : IInitializable
    {
        private MovementPoint _activePoint;

        private readonly Camera _camera;
        private readonly CursorService _cursorService;
        private readonly MovementFadeView _fadeView;
        private readonly MovementControlView _controlView;
        private readonly float _movementDuration;
        
        public MovementService(Camera camera, CursorService cursorService,
            MovementFadeView fadeView, MovementControlView controlView,
            MovementPoint initialMovementPoint,
            float movementDuration)
        {
            _camera = camera;
            _cursorService = cursorService;
            _fadeView = fadeView;
            _controlView = controlView;
            _movementDuration = movementDuration;
            _activePoint = initialMovementPoint;
        }

        public void Initialize()
        {
            _controlView.Setup(this, _cursorService);
            UpdateControlsAndCamera();
        }

        public void RotateRight() => Move(_activePoint.RightPoint);
        public void RotateLeft() => Move(_activePoint.LeftPoint);
        public void MoveBack() => Move(_activePoint.BackPoint);
        
        public void Move(MovementPoint point)
        {
            _activePoint = point;
            UniTask.Void(async cancellationToken =>
            {
                await _fadeView.FadeIn();
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Delay(System.TimeSpan.FromSeconds(_movementDuration),
                    cancellationToken: cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                UpdateControlsAndCamera();
                await _fadeView.FadeOut();
            }, _fadeView.gameObject.GetCancellationTokenOnDestroy());
        }

        private void UpdateControlsAndCamera()
        {
            _controlView.UpdateControlsFor(_activePoint);

            var cameraTransform = _camera.transform;
            var activePointTransform = _activePoint.transform;
            cameraTransform.position = activePointTransform.position;
            cameraTransform.rotation = activePointTransform.rotation;
            _camera.fieldOfView = _activePoint.Fov;
        }
    }
}