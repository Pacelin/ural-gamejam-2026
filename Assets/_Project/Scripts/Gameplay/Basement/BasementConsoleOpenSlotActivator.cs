using Project.Gameplay.Interactables;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleOpenSlotActivator : PuzzleActivator
    {
        [SerializeField] private BasementConsoleSlot _slot;

        private void OnValidate()
        {
            if (!_slot)
                _slot = GetComponentInParent<BasementConsoleSlot>();
        }

        public override void Activate() => _slot.Open();
    }
}