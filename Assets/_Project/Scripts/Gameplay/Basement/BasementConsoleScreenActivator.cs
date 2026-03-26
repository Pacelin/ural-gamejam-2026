using Plugins.Audio;
using Project.Gameplay.Interactables;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleScreenActivator : PuzzleActivator
    {
        [SerializeField] private BasementConsoleScreen _consoleScreen;
        [SerializeField] private EBasementConsoleScreenAction _action;
        [SerializeField] private bool _useSound;
        [SerializeField] private SoundEvent _actionSound;
        
        private void OnValidate()
        {
            if (!_consoleScreen)
                _consoleScreen = FindFirstObjectByType<BasementConsoleScreen>();
        }

        public override void Activate()
        {
            if (_useSound)
                _consoleScreen.PlaySound(_actionSound);
            _consoleScreen.StartAction(_action);
        }
    }
}