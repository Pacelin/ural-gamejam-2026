namespace Project.Gameplay.Inventory
{
    public class InventoryTextController
    {
        private readonly InventoryView _view;
        
        private InventoryItemEntry _holdItem;
        private InventoryItemEntry _hoverItem;
        
        public InventoryTextController(InventoryView view)
        {
            _view = view;
            _view.SetTextActive(false);
        }

        public void SetHold(InventoryItemEntry item)
        {
            _holdItem = item;
            UpdateText();
        }

        public void SetHover(InventoryItemEntry item)
        {
            _hoverItem = item;
            UpdateText();
        }

        public void OnDestroyItem(InventoryItemEntry item)
        {
            if (_hoverItem == item)
            {
                _hoverItem = null;
                UpdateText();
            }

            if (_holdItem == item)
            {
                _holdItem = null;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (_holdItem != null)
            {
                _view.SetTextActive(true);
                _view.SetText(_holdItem.Text);
            }
            else if (_hoverItem != null)
            {
                _view.SetTextActive(true);
                _view.SetText(_hoverItem.Text);
            }
            else
            {
                _view.SetTextActive(false);
            }
        }
    }
}