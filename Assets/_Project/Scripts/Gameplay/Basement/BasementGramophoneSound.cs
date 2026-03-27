using System;
using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneSound : MonoBehaviour
    {
        [SerializeField] private BasementGramophoneIgla _igla;
        [SerializeField] private BasementGramophoneVelocity _velocity;
        [SerializeField] private Transform _soundPoint;

        private SoundEvent_Music_GramophoneEvent.Instance _instance;
        private const float TOLERANCE = 0.0001f;
        
        private void Awake()
        {
            _instance = AudioSystem.Music_GramophoneEvent.CreateInstance();
            _instance.SetWorldPosition(_soundPoint.position);
            _instance.Start();
            _instance.SetPaused(true);
        }

        private void OnDestroy()
        {
            _instance.Stop(false);
            _instance.Release();
            _instance = null;
        }

        private void Update()
        {
            var currentParameterValue = _instance.GetGramophoneVelocity();
            var currentPaused = _instance.GetPaused();
            var targetParameterValue = _velocity.NormalizedAngularVelocity;
            var targetPaused = targetParameterValue < TOLERANCE || !_igla.IsActive;

            if (Math.Abs(currentParameterValue - targetParameterValue) > TOLERANCE)
                _instance.SetGramophoneVelocity(targetParameterValue);
            if (currentPaused != targetPaused)
                _instance.SetPaused(targetPaused);
        }
    }
}