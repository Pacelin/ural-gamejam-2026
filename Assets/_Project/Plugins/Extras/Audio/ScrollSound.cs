using Plugins.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Extras
{
    public class ScrollSound : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void OnEnable() => _slider.onValueChanged.AddListener(OnScroll);
        private void OnDisable() => _slider.onValueChanged.RemoveListener(OnScroll);

        private void OnScroll(float arg0) => AudioSystem.UI_Scroll.PlayOneShot();
    }
}