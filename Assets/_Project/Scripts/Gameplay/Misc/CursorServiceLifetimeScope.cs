using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Misc
{
    public class CursorServiceLifetimeScope : LifetimeScope
    {
        [SerializeField] private CursorSettings _settings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_settings);
            builder.RegisterEntryPoint<CursorService>().AsSelf();
        }
    }
}