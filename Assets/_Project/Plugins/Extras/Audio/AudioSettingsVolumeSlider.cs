using Plugins.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Extras
{
    public class AudioSettingsVolumeSlider : MonoBehaviour
    {
        [SerializeField] private int[] _busIndex;
        [SerializeField] private Slider _slider;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Image[] _gradientTargets;

        private void OnEnable()
        {
            var value = AudioSystem.Volumes.GetVolume(_busIndex[0]);
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
            foreach (var busIndex in _busIndex)
                AudioSystem.Volumes.SetVolume(busIndex, value);
            foreach (var gradientTarget in _gradientTargets)
                gradientTarget.color = _gradient.Evaluate(value);
        }
    }
}