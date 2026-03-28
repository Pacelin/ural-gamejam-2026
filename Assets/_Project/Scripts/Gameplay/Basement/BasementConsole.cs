using System.Linq;
using Cysharp.Threading.Tasks;
using Project.Gameplay.Interactables;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsole : NotInteractableObject
    {
        [SerializeField] private BasementConsoleEnterButton _enterButton;
        [SerializeField] private BasementConsoleScreens _screens;
        [SerializeField] private BasementConsoleButton[] _buttons;
        [SerializeField] private BasementConsoleCommand[] _commands;
        [SerializeField] private float _commandEnterDuration = 1.6f;
        [SerializeField] private float _consoleLockDuration = 2.1f;

        private MovementService _movementService;
        
        protected override void OnValidate()
        {
            base.OnValidate();
            if (!_enterButton)
                _enterButton = FindFirstObjectByType<BasementConsoleEnterButton>();
            if (!_screens)
                _screens = FindFirstObjectByType<BasementConsoleScreens>();
            if (_commands == null || _commands.Length == 0)
                _commands = FindObjectsByType<BasementConsoleCommand>(FindObjectsSortMode.None);
            if (_buttons == null || _buttons.Length == 0)
                _buttons = FindObjectsByType<BasementConsoleButton>(FindObjectsSortMode.None);
        }

        protected override void Initialize(IObjectResolver resolver)
        {
            _movementService = resolver.Resolve<MovementService>();
        }

        public void EnterCommand()
        {
            var activeButtons = _buttons
                .Where(b => b.Selected).ToArray();

            BasementConsoleCommand selectedCommand = null;
            
            foreach (var command in _commands)
            {
                if (command.ActiveButtons.Count != activeButtons.Length)
                    continue;
                var intersectCount = activeButtons.Intersect(command.ActiveButtons)
                    .Count();
                if (intersectCount != activeButtons.Length)
                    continue;

                selectedCommand = command;
                break;
            }
            
            foreach (var button in activeButtons)
                button.SetSelected(false);
            
            EnterCommand(selectedCommand);
        }

        private void EnterCommand(BasementConsoleCommand command)
        {
            _screens.SetupCommand(command);

            if (command)
            {
                UniTask.Void(async cancellationToken =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await UniTask.Delay(System.TimeSpan.FromSeconds(_commandEnterDuration),
                        cancellationToken: cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                    command.Execute();
                }, this.GetCancellationTokenOnDestroy());
            }
            
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _enterButton.SetBlock(true);
                _movementService.BlockControls();
                
                await UniTask.Delay(System.TimeSpan.FromSeconds(_consoleLockDuration),
                    cancellationToken: cancellationToken);
                
                cancellationToken.ThrowIfCancellationRequested();
                _enterButton.SetBlock(false);
                _movementService.UnblockControls();
            }, this.GetCancellationTokenOnDestroy());
        }
    }
}