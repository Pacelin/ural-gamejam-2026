using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Core.Pause
{
    public class PauseWindowLifetimeScope : LifetimeScope
    {
        [SerializeField] private PauseWindow _windowPrefab;
        [SerializeField] private AcceptPopup _acceptExitPopupPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_windowPrefab, Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab(_acceptExitPopupPrefab, Lifetime.Singleton);
            
            builder.RegisterEntryPoint<PauseWindowController>();
            
            builder.RegisterBuildCallback(o =>
            {
                o.Resolve<AcceptPopup>().gameObject.SetActive(false);
                o.Resolve<PauseWindow>().gameObject.SetActive(false);
            });
        }
    }
}