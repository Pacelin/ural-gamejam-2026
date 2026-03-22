using VContainer;
using VContainer.Unity;

namespace Project.Editor.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayMusicController>();
        }
    }
}