using DG.Tweening;
using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementLight : MonoBehaviour
    {
        [SerializeField] private float[] _delays;
        [SerializeField] private float[] _durations;
        [SerializeField] private float[] _intensities;
        [SerializeField] private Light _light;
        [Space] 
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _tickSound;
        [SerializeField] private SoundEvent _onSound;
        [Space]
        [SerializeField] private Vector2 _randomTickDelays;
        [SerializeField] private float _lowTickIntensity;
        [SerializeField] private float _tickDuration;
        [Space]
        [SerializeField] private float _doubleTickChance;
        [SerializeField] private Vector2 _doubleTickDelays;

        private float _currentRandomTickDelays;
        private float _tickCooldown;
        private ISoundEventInstance _soundEventInstance;
        
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
            {
                UpdateCooldown();
                Tick();
            }
        }

        public void Activate()
        {
            _tickCooldown = Random.Range(_randomTickDelays.x, _randomTickDelays.y);
            gameObject.SetActive(true);
            _soundEventInstance = _onSound.CreateInstance();
            _soundEventInstance.SetWorldPosition(_soundPoint.position);
            _soundEventInstance.Start();
            
            var seq = DOTween.Sequence(_light);
            for (int i = 0; i < _intensities.Length; i++)
            {
                seq.AppendInterval(_delays[i]);
                seq.AppendCallback(() => _tickSound.PlayOneShotInPoint(_soundPoint.position));
                seq.Append(_light.DOIntensity(_intensities[i], _durations[i]));
            }
        }

        private void Tick()
        {
            _tickSound.PlayOneShotInPoint(_soundPoint.position);
            var halfDuration = _tickDuration / 2f;
            var startIntensity = _light.intensity;
            DOTween.Sequence(_light)
                .Append(_light.DOIntensity(_lowTickIntensity, halfDuration))
                .Append(_light.DOIntensity(startIntensity, halfDuration));
        }

        private void UpdateCooldown()
        {
            var randomValue = Random.value;
            if (randomValue <= _doubleTickChance)
                _tickCooldown = Random.Range(_randomTickDelays.x, _randomTickDelays.y);
            else
                _tickCooldown = Random.Range(_doubleTickDelays.x, _doubleTickDelays.y);
        }
    }
}