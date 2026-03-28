using System.Collections.Generic;
using System.Linq;
using Project.Gameplay.Interactables;
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
        }

        public void Execute()
        {
            _onApplyCommand.Trigger(SubtitlesService);
        }
    }
}