using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Editor.Gameplay
{
    public class BasementLifetimeScope : LifetimeScope
    {
        [SerializeField] private CollectablesView _collectablesView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BasementMusicController>();

            builder.RegisterEntryPoint<CollectablesController>()
                .WithParameter(_collectablesView);
        }
    }
}