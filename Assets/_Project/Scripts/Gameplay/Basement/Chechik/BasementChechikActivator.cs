using Project.Gameplay.Interactables;

namespace Project.Gameplay.Basement
{
    public class BasementChechikActivator : PuzzleActivator
    {
        private bool _activated;
        
        public override void Activate()
        {
            if (_activated)
                return;

            _activated = true;
        }
    }
}