using UnityEngine;

namespace Plugins.Extras
{
    public class PauseLifetime : MonoBehaviour
    {
        private void OnEnable() => PauseManager.HandlePauseByKey = true;
        private void OnDisable() => PauseManager.HandlePauseByKey = false;
    }
}