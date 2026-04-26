using System;
using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneSound : MonoBehaviour
    {
        [SerializeField] private BasementGramophoneSlot _slot;
        [SerializeField] private BasementGramophoneIgla _igla;
        [SerializeField] private BasementGramophoneVelocity _velocity;
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent[] _sounds;
        
        private SoundEvent _activeSound;
        private SoundEventInstance _instance;
        private const float TOLERANCE = 0.0001f;
        
        private void OnDestroy()
        {
            if (_instance != null)
            {
                _instance.Stop(false);
                _instance.Release();
                _instance = null;
            }
        }

        private void UpdateInstance()
        {
            var selectedSound = _slot.InsertedIndex == -1 ? null : _sounds[_slot.InsertedIndex];
            if (_activeSound == selectedSound)
                return;

            _activeSound = selectedSound;
            if (_instance != null)
            {
                _instance.Stop(false);
                _instance.Release();
                _instance = null;
            }

            if (selectedSound != null)
            {
                _instance = selectedSound.CreateInstance();
                _instance.SetWorldPosition(_soundPoint.position);
                _instance.Start();
                _instance.SetPaused(true);
            }
        }
        
        private void Update()
        {
            UpdateInstance();
            if (_instance == null)
                return;
            
            var currentParameterValue = AudioSystem.Global.GetGramophoneVelocity();
            var currentPaused = _instance.GetPaused();
            var targetParameterValue = _velocity.NormalizedAngularVelocity;
            var targetPaused = targetParameterValue < TOLERANCE || !_igla.IsActive;

            if (Math.Abs(currentParameterValue - targetParameterValue) > TOLERANCE)
                AudioSystem.Global.SetGramophoneVelocity(targetParameterValue);
            if (currentPaused != targetPaused)
                _instance.SetPaused(targetPaused);
        }
    }
}