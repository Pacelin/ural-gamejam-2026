using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Inventory
{
    public class InventoryLifetimeScope : LifetimeScope
    {
        [SerializeField] private InventoryItemConfig[] _initialItems;
        [SerializeField] private InventoryView _inventoryView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InventoryModel>(Lifetime.Singleton)
                .WithParameter(_initialItems);
            builder.RegisterEntryPoint<InventoryController>()
                .WithParameter(_inventoryView);
        }
    }
}