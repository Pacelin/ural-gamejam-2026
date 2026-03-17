using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Misc
{
    public class SubtitlesLifetimeScope : LifetimeScope
    {
        [SerializeField] private SubtitlesView _subtitlesView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SubtitlesService>(Lifetime.Singleton)
                .WithParameter(_subtitlesView);
        }
    }
}