using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Movement
{
    public class MovementServiceLifetimeScope : LifetimeScope
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private MovementFadeView _fadeView;
        [SerializeField] private MovementControlView _controlView;
        [SerializeField] private MovementPoint _initialMovementPoint;
        [SerializeField] private float _movementDuration;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MovementService>()
                .WithParameter(_camera)
                .WithParameter(_fadeView)
                .WithParameter(_controlView)
                .WithParameter(_initialMovementPoint)
                .WithParameter(_movementDuration)
                .AsSelf();
        }
    }
}