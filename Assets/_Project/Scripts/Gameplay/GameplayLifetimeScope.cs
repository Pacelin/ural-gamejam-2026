using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Editor.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private int _requireCollectables;
        [SerializeField] private CollectablesView _collectablesView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayMusicController>();

            builder.RegisterInstance(new CollectablesModel(0, _requireCollectables));
            builder.RegisterEntryPoint<CollectablesController>()
                .WithParameter(_collectablesView);
        }
    }
}