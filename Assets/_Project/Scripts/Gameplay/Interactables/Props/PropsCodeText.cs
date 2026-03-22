using System;
using Plugins.Audio;
using TMPro;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PropsCodeText : MonoBehaviour
    {
        public string CurrentValue => _values[_currentIndex];
        
        [SerializeField] private CodePuzzle _puzzle;
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string[] _values;
        [SerializeField] private SoundEvent _onChangedSound;

        private int _currentIndex;
        
        private void Awake() => _text.text = _values[0];

        public void Increase()
        {
            _currentIndex = (_currentIndex + 1) % _values.Length;
            UpdateText();
        }

        public void Decrease()
        {
            _currentIndex = (_currentIndex + _values.Length - 1) % _values.Length;
            UpdateText();
        }

        private void UpdateText()
        {
            _onChangedSound.PlayOneShotInPoint(_soundPoint.position);
            _text.text = _values[_currentIndex];
            if (_puzzle)
                _puzzle.CheckCompletion();
        }
    }
}