namespace Project.Editor.Gameplay
{
    public class CollectablesModel
    {
        public event System.Action OnChanged;

        public int Current => _current;
        public int Required => _required;
        
        private int _current;
        
        private readonly int _required;
        
        public CollectablesModel(int current, int required)
        {
            _current = current;
            _required = required;
        }

        public void Add()
        {
            _current++;
            OnChanged?.Invoke();
        }

        public bool AllCollected() => _current >= _required;
    }
}