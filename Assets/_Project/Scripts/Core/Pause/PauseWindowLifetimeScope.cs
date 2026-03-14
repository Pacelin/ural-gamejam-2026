using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Core.Pause
{
    public class PauseWindowLifetimeScope : LifetimeScope
    {
        [SerializeField] private PauseWindow _windowPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_windowPrefab, Lifetime.Singleton)
                .UnderTransform(transform);
            
            builder.RegisterEntryPoint<PauseWindowController>();
            
            builder.RegisterBuildCallback(o =>
            {
                o.Resolve<PauseWindow>().gameObject.SetActive(false);
            });
        }
    }
}