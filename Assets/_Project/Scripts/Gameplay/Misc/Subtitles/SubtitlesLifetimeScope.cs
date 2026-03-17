using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Misc
{
    public class SubtitlesLifetimeScope : LifetimeScope
    {
        [SerializeField] private SubtitlesView _subtitlesPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_subtitlesPrefab, Lifetime.Singleton);
            builder.Register<SubtitlesService>(Lifetime.Singleton);
        }
    }
}