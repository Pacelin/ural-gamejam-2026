using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay
{
    public abstract class GameplayLifetimeInstaller : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}