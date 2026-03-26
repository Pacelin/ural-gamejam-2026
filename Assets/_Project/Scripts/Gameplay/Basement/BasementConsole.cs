using System.Linq;
using Project.Gameplay.Interactables;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsole : NotInteractableObject
    {
        [SerializeField] private BasementConsoleButton[] _buttons;
        [SerializeField] private BasementConsoleCommand[] _commands;
        [SerializeField] private PropsEvents _onFailEnter;

        protected override void OnValidate()
        {
            base.OnValidate();
            if (_buttons == null || _buttons.Length == 0)
            {
                _buttons = FindObjectsByType<BasementConsoleButton>(FindObjectsSortMode.None);
            }
        }

        protected override void Initialize(IObjectResolver resolver) { }

        public void EnterCommand()
        {
            var activeButtons = _buttons
                .Where(b => b.Selected).ToArray();

            foreach (var command in _commands)
            {
                if (command.ActiveButtons.Count != activeButtons.Length)
                    continue;
                var intersectCount = activeButtons.Intersect(command.ActiveButtons)
                    .Count();
                if (intersectCount != activeButtons.Length)
                    continue;
                
                command.Execute();
                foreach (var button in activeButtons)
                    button.SetSelected(false);
                return;
            }
            
            _onFailEnter?.Trigger(SubtitlesService);
            foreach (var button in activeButtons)
                button.SetSelected(false);
        }
    }
}