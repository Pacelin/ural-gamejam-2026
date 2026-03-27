using VContainer;
using VContainer.Unity;

namespace Project.Core
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BootstrapStarter>();
        }
    }
}