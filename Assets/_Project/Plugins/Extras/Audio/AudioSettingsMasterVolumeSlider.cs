using Plugins.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Extras
{
    public class AudioSettingsMasterVolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Image[] _gradientTargets;

        private void OnEnable()
        {
            var value = AudioSystem.Volumes.MasterVolume;        
            _slider.SetValueWithoutNotify(value);
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            foreach (var gradientTarget in _gradientTargets)
                gradientTarget.color = _gradient.Evaluate(value);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        } 

        private void OnSliderValueChanged(float value)
        {
            foreach (var gradientTarget in _gradientTargets)
                gradientTarget.color = _gradient.Evaluate(value);
            AudioSystem.Volumes.MasterVolume = value;
        }
    }
}