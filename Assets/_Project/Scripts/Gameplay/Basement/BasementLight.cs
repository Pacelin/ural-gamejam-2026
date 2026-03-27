using System;
using DG.Tweening;
using Plugins.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Gameplay.Basement
{
    public class BasementLight : MonoBehaviour
    {
        [SerializeField] private Vector2 _randomDelay;
        [SerializeField] private Vector2 _randomIntensities;
        [SerializeField] private Vector2 _randomLowIntensities;
        [SerializeField] private Vector2 _lowDelayOnStart;
        [SerializeField] private Vector2Int _randomTickCount;
        [SerializeField] private Vector2 _randomDurations;
        [SerializeField] private Vector2 _randomLastIntensity;
        [SerializeField] private Light _light;
        [Space] 
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _tickSound;
        [SerializeField] private SoundEvent _onSound;
        [Space]
        [SerializeField] private Vector2 _randomTickDelays;
        [SerializeField] private Vector2 _lowDelayTick;
        [SerializeField] private float _lowTickIntensity;
        [SerializeField] private float _tickDuration;
        [Space]
        [SerializeField] private float _doubleTickChance;
        [SerializeField] private Vector2 _doubleTickDelays;
        [SerializeField] private bool _activateOnAwake = false;

        private float _currentRandomTickDelays;
        private float _tickCooldown;
        private ISoundEventInstance _soundEventInstance;

        private void Start()
        {
            if (_activateOnAwake)
                Activate();
        }

        private void OnDestroy()
        {
            if (_soundEventInstance != null && _soundEventInstance.IsValid())
            {
                _soundEventInstance.Stop(false);
                _soundEventInstance.Release();
                _soundEventInstance = null;
            }
            
            DOTween.Kill(_light);
        }
        
        private void Update()
        {
            _tickCooldown -= Time.deltaTime;
            if (_tickCooldown <= 0)
                Tick();
        }

        public void Activate()
        {
            _tickCooldown = Random.Range(_randomTickDelays.x, _randomTickDelays.y);
            gameObject.SetActive(true);
            _soundEventInstance = _onSound.CreateInstance();
            _soundEventInstance.SetWorldPosition(_soundPoint.position);
            _soundEventInstance.Start();
            
            var seq = DOTween.Sequence(_light);
            var count = Random.Range(_randomTickCount.x, _randomTickCount.y);
            for (int i = 0; i < count; i++)
            {
                var delay = Random.Range(_randomDelay.x, _randomDelay.y);
                var intensity = i == count - 1
                    ? Random.Range(_randomLastIntensity.x, _randomLastIntensity.y)
                    : Random.Range(_randomIntensities.x, _randomIntensities.y);
                var lowIntensity = Random.Range(_randomLowIntensities.x, _randomLowIntensities.y);
                var duration = Random.Range(_randomDurations.x, _randomDurations.y) / 2;
                var lowDelay = Random.Range(_lowDelayOnStart.x, _lowDelayOnStart.y);
                seq.AppendInterval(delay);
                seq.AppendCallback(() => _tickSound.PlayOneShotInPoint(_soundPoint.position));
                seq.Append(_light.DOIntensity(lowIntensity, duration));
                seq.AppendInterval(lowDelay);
                seq.AppendCallback(() => _tickSound.PlayOneShotInPoint(_soundPoint.position));
                seq.Append(_light.DOIntensity(intensity, duration));
            }
        }

        private void Tick()
        {
            var halfDuration = _tickDuration / 2f;
            var startIntensity = _light.intensity;
            var lowDelay = Random.Range(_lowDelayTick.x, _lowDelayTick.y);
            DOTween.Sequence(_light)
                .AppendCallback(() => _tickSound.PlayOneShotInPoint(_soundPoint.position))
                .Append(_light.DOIntensity(_lowTickIntensity, halfDuration))
                .AppendInterval(lowDelay)
                .AppendCallback(() => _tickSound.PlayOneShotInPoint(_soundPoint.position))
                .Append(_light.DOIntensity(startIntensity, halfDuration));
            UpdateCooldown(lowDelay + halfDuration * 2);
        }

        private void UpdateCooldown(float withDelay)
        {
            var randomValue = Random.value;
            if (randomValue <= _doubleTickChance)
                _tickCooldown = withDelay + Random.Range(_randomTickDelays.x, _randomTickDelays.y);
            else
                _tickCooldown = withDelay + Random.Range(_doubleTickDelays.x, _doubleTickDelays.y);
        }
    }
}