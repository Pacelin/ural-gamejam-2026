using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameplayLifetimeInstaller[] _installers;
        
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _installers)
                installer.Install(builder);
        }
    }
}