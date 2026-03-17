using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Misc
{
    public class CursorServiceLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(Resources.Load<CursorSettings>("SO_CursorSettings"));
            builder.RegisterEntryPoint<CursorService>().AsSelf();
        }
    }
}