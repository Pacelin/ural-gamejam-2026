using Project.Gameplay.Interactables;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleOpenSlotActivator : PuzzleActivator
    {
        [SerializeField] private BasementConsoleSlot _slot;
        public override void Activate() => _slot.Open();
    }
}