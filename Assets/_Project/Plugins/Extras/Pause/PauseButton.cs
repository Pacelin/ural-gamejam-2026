using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Extras
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private void OnEnable() => _button.onClick.AddListener(OnButtonClick);
        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);
        private void OnButtonClick() => PauseManager.SetPause(EPauseState.PausedByUser, true);
    }
}