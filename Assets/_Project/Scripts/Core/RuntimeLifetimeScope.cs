using Project.Core.Misc;
using Project.Core.Pause;
using VContainer;
using VContainer.Unity;

namespace Project.Core
{
    public class RuntimeLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameModel>(Lifetime.Singleton);
            builder.Register<RuntimeSetup>(Lifetime.Singleton);
            builder.RegisterEntryPoint<RuntimeEntryPoint>();
            builder.RegisterEntryPoint<EscapeController>().AsSelf();
            builder.RegisterEntryPoint<PauseController>().AsSelf();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}