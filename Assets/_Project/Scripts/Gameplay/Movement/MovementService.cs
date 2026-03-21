using System;
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
        private MovementPoint _previousPoint;

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
            _activePoint.gameObject.SetActive(true);
            foreach (var p in _activePoint.ActiveWhenOnPoint)
                p.gameObject.SetActive(true);
            
            _controlView.UpdateControlsFor(_activePoint);

            var activePointTransform = _activePoint.transform;
            _cameraController.Set(activePointTransform.position, activePointTransform.rotation);
        }

        public void RotateRight() => Move(_activePoint.RightPoint);
        public void RotateLeft() => Move(_activePoint.LeftPoint);
        public void MoveBack()
        {
            if (_activePoint.UsePreviousPointWhenBack)
                Move(_previousPoint, _activePoint.UseSoundWhenBack);
            else
                Move(_activePoint.BackPoint, _activePoint.UseSoundWhenBack);
        }

        public void BlockControls()
        {
            _cursorService.EnableCursorState(ECursorState.Transition);
            _blockView.Block();
        }

        public void UnblockControls()
        {
            _cursorService.DisableCursorState(ECursorState.Transition);
            _blockView.Unblock();
        }
        
        public void Move(MovementPoint point, bool useMoveSound = true)
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _cursorService.EnableCursorState(ECursorState.Transition);
                _blockView.Block();
                
                _activePoint.gameObject.SetActive(false);
                foreach (var p in _activePoint.ActiveWhenOnPoint)
                    if (p)
                        p.gameObject.SetActive(false);
    
                point.gameObject.SetActive(true);
                foreach (var p in point.ActiveWhenOnPoint)
                    if (p)
                        p.SetActive(true);
                
                _controlView.UpdateControlsFor(point);

                var pointTransform = point.transform;
                await MoveTo(pointTransform.position, pointTransform.rotation, useMoveSound, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
                _previousPoint = _activePoint;
                _activePoint = point;
                _blockView.Unblock();
                _cursorService.DisableCursorState(ECursorState.Transition);
            }, _blockView.gameObject.GetCancellationTokenOnDestroy());
        }

        public void MoveInDoor(MovementPoint point, Vector3 doorPoint, ISoundEvent moveSound)
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _cursorService.EnableCursorState(ECursorState.Transition);
                _blockView.Block();
                
                _activePoint.gameObject.SetActive(false);
                foreach (var p in _activePoint.ActiveWhenOnPoint)
                    if (p)
                        p.gameObject.SetActive(false);
                point.gameObject.SetActive(true);
                foreach (var p in point.ActiveWhenOnPoint)
                    if (p)
                        p.SetActive(true);
                
                _controlView.UpdateControlsFor(point);

                var pointTransform = point.transform;
                var moveTask = MoveTo(pointTransform.position, pointTransform.rotation, doorPoint, cancellationToken);
                
                await UniTask.Delay(TimeSpan.FromSeconds(0.2f), cancellationToken: cancellationToken);
                moveSound.PlayOneShotInPoint(doorPoint);
                cancellationToken.ThrowIfCancellationRequested();
                await _blockView.FadeIn();
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                await _blockView.FadeOut();
                cancellationToken.ThrowIfCancellationRequested();

                await moveTask;
                
                cancellationToken.ThrowIfCancellationRequested();
                _previousPoint = _activePoint;
                _activePoint = point;
                _blockView.Unblock();
                _cursorService.DisableCursorState(ECursorState.Transition);
            }, _blockView.gameObject.GetCancellationTokenOnDestroy());
        }

        private async UniTask MoveTo(Vector3 position, Quaternion rotation, bool useMoveSound, CancellationToken cancellationToken)
        {
            var cameraPosition = _cameraController.GetPosition();

            var distance = Vector3.Distance(cameraPosition, position);
            var duration = Mathf.Clamp(distance * _movementConfig.MoveDurationPerMeter,
                _movementConfig.MinMoveDuration, _movementConfig.MaxMoveDuration);
            
            if (useMoveSound && distance > 0.2f)
            {
                _cameraController.MakeMoveImpulse(duration);
                AudioSystem.Game_Characters_PlayerWalk.PlayOneShot();
            }
            await _cameraController.MoveTo(position, rotation, duration,
                cancellationToken);
        }
        
        private async UniTask MoveTo(Vector3 position, Quaternion rotation, Vector3 doorPosition, 
            CancellationToken cancellationToken)
        {
            var cameraPosition = _cameraController.GetPosition();

            var distance = Vector3.Distance(cameraPosition, position);
            var duration = Mathf.Clamp(distance * _movementConfig.MoveDurationPerMeter,
                _movementConfig.MinMoveDuration, _movementConfig.MaxMoveDuration);
            
            _cameraController.MakeMoveImpulse(duration);
            await _cameraController.MoveTo(position, rotation, duration, doorPosition,
                cancellationToken);
        }
    }
}