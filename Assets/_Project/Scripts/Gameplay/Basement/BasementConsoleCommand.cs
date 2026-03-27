using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Project.Gameplay.Interactables;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleCommand : NotInteractableObject
    {
        public IReadOnlyList<BasementConsoleButton> ActiveButtons => _activeButtons;

        [SerializeField] private string _codeDebug;
        [Space]
        [SerializeField] private BasementConsoleButton[] _activeButtons;
        [SerializeField] private PropsEvents _onApplyCommand;
        [SerializeField] private float _blockPlayerMovementDuration;

        private MovementService _movementService;

#if UNITY_EDITOR
        [ContextMenu("Attach Buttons by Debug Code")]
        private void AttachButtons()
        {
            var codes = _codeDebug.Split(' ');
            var allButtons = FindObjectsByType<BasementConsoleButton>(FindObjectsSortMode.None);
            var correctButtons = allButtons.Where(button =>
            {
                var keyName = button.transform.parent.gameObject.name;
                var keyCode = keyName.Split('_')[1];
                return codes.Contains(keyCode);
            });
            _activeButtons = correctButtons.ToArray();
        }
#endif
        
        protected override void Initialize(IObjectResolver resolver)
        {
            _movementService = resolver.Resolve<MovementService>();
        }

        public void Execute()
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _onApplyCommand.Trigger(SubtitlesService);
                _movementService.BlockControls();

                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Delay(TimeSpan.FromSeconds(_blockPlayerMovementDuration), 
                    cancellationToken: cancellationToken);
                
                cancellationToken.ThrowIfCancellationRequested();
                _movementService.UnblockControls();
            }, this.GetCancellationTokenOnDestroy());
        }
    }
}