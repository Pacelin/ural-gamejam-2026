using Project.Editor.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Basement
{
    public class FinalLifetimeScope : LifetimeScope
    {
        [SerializeField] private int _collectablesCount = 8;
        [SerializeField] private int _maxCount = 8;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(new CollectablesModel(_collectablesCount, _maxCount));
        }
    }
}