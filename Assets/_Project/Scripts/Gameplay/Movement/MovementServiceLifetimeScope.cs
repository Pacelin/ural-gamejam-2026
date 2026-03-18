using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Movement
{
    public class MovementServiceLifetimeScope : LifetimeScope
    {
        [SerializeField] private MovementBlockView _blockView;
        [SerializeField] private MovementControlView _controlView;
        [SerializeField] private MovementCameraController _cameraController;
        [SerializeField] private MovementPoint _initialMovementPoint;
        [SerializeField] private float _movementDuration;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MovementService>()
                .WithParameter(_blockView)
                .WithParameter(_controlView)
                .WithParameter(_cameraController)
                .WithParameter(_initialMovementPoint)
                .WithParameter(_movementDuration)
                .AsSelf();
        }
    }
}