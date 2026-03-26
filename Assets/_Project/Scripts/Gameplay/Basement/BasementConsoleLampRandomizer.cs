using UnityEditor;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleLampRandomizer : MonoBehaviour
    {
        [SerializeField] private BasementConsoleLamp[] _lamps;
        [ColorUsage(false, true)]
        [SerializeField] private Color[] _colors;
        [SerializeField] private Vector2 _delayRange;

        private void OnValidate()
        {
            if (_lamps == null || _lamps.Length == 0)
            {
                _lamps = FindObjectsByType<BasementConsoleLamp>(FindObjectsSortMode.None);
            }
        }

        [ContextMenu("Generate")]
        private void Generate()
        {
            foreach (var lamp in _lamps)
            {
                var delay = Random.Range(_delayRange.x, _delayRange.y);
                lamp._delay = delay;
                var color = _colors[Random.Range(0, _colors.Length - 1)];
                lamp._lightColor = color;
                EditorUtility.SetDirty(lamp);
            }
        }
    }
}