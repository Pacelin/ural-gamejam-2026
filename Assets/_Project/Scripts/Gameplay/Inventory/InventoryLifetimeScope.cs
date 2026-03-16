using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Gameplay.Inventory
{
    public class InventoryLifetimeScope : LifetimeScope
    {
        [SerializeField] private InventoryItemConfig[] _initialItems;
        [SerializeField] private InventoryView _inventoryViewPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(new InventoryModel(_initialItems));
            builder.RegisterComponentInNewPrefab(_inventoryViewPrefab, Lifetime.Singleton);
            builder.RegisterEntryPoint<InventoryController>();
        }
    }
}