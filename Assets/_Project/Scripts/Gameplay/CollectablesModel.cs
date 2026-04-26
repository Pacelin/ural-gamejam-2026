using System.Collections.Generic;
using Project.Gameplay.Inventory;

namespace Project.Editor.Gameplay
{
    public class CollectablesModel
    {
        public event System.Action OnChanged;

        public int Current => _current;
        public int Required => _required;
        public int LastCollected => _lastCollected;
        
        private int _current;
        private int _lastCollected;

        private readonly HashSet<int> _collected;
        private readonly int _required;
        
        public CollectablesModel(int current, int required)
        {
            _current = current;
            _required = required;
            _collected = new HashSet<int>();
        }

        public bool IsCollected(int index) => _collected.Contains(index);
        
        public void Add(int collectableIndex)
        {
            _collected.Add(collectableIndex);
            _lastCollected = collectableIndex;
            _current++;
            OnChanged?.Invoke();
        }

        public bool AllCollected() => _current >= _required;
    }
}