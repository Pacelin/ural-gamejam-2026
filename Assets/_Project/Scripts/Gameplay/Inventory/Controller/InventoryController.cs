using System.Collections.Generic;
using JetBrains.Annotations;
using Project.Gameplay.Misc;
using VContainer.Unity;

namespace Project.Gameplay.Inventory
{
    [UsedImplicitly]
    public class InventoryController : IInitializable, System.IDisposable
    {
        private readonly InventoryView _view;
        private readonly InventoryModel _model;
        private readonly InventoryTextController _textController;
        private readonly InventoryDragController _dragController;
        private readonly List<InventoryItemController> _itemsControllers;
        
        public InventoryController(InventoryView view, InventoryModel model, CursorService cursorService)
        {
            _view = view;
            _model = model;
            _textController = new InventoryTextController(_view);
            _dragController = new InventoryDragController(_view.DragView, _textController, cursorService);
            _itemsControllers = new List<InventoryItemController>();
        }
        
        public void Initialize()
        {
            _model.OnAddItem += OnAddItem;
            _model.OnRemoveItem += OnRemoveItem;
            
            foreach (var item in _model.Items)
                OnAddItem(item);
            
            _dragController.Initialize();
        }

        public void Dispose()
        {
            _model.OnAddItem -= OnAddItem;
            _model.OnRemoveItem -= OnRemoveItem;
            
            foreach (var item in _itemsControllers)
                item.Dispose();
            
            _dragController.Dispose();
        }
        
        private void OnAddItem(InventoryItemEntry item)
        {
            var itemView = _view.CreateItem();
            var itemController = new InventoryItemController(item, _view, itemView, _textController, _dragController);
            itemController.Initialize();
            
            _itemsControllers.Add(itemController);
        }

        private void OnRemoveItem(InventoryItemEntry item)
        {
            var index = _itemsControllers.FindIndex(i => i.Item == item);
            var controller = _itemsControllers[index];
            controller.DestroyItem();
            controller.Dispose();
            _itemsControllers.RemoveAt(index);
        }
    }
}