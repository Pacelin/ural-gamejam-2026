using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.MainMenu
{
    public class MainMenuLifetimeScope : LifetimeScope
    {
        [SerializeField] private MainMenuWindow _windowPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_windowPrefab, Lifetime.Singleton);
            builder.RegisterEntryPoint<MainMenuController>();
        }
    }
}