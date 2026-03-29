using System.Collections.Generic;
using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementRandomSound : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private SoundEvent[] _sounds;
        [SerializeField] private Vector2 _delaysRange;
        [SerializeField] private float _startDelay;
        [SerializeField] private Vector2 _distanceRange;

        private readonly Queue<SoundEvent> _soundsQueue = new Queue<SoundEvent>();

        private float _cooldown;

        private void Awake()
        {
            _cooldown = _startDelay;
        }

        private void Update()
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown < 0)
            {
                PlaySound();
                _cooldown = Random.Range(_delaysRange.x, _delaysRange.y);
            }
        }

        private void PlaySound()
        {
            var sound = GetSound();
            var position = GetPointPosition();
            sound.PlayOneShotInPoint(position);
        }

        private SoundEvent GetSound()
        {
            if (_soundsQueue.Count == 0)
            {
                Shuffle(_sounds);
                foreach (var sound in _sounds)
                    _soundsQueue.Enqueue(sound);
            }

            return _soundsQueue.Dequeue();
        }

        private Vector3 GetPointPosition()
        {
            var direction = Random.insideUnitCircle.normalized;
            var direction3d = new Vector3(direction.x, 0, direction.y);
            var vector = direction3d * Random.Range(_distanceRange.x, _distanceRange.y);

            return _root.position + vector;
        }
        
        private void Shuffle(SoundEvent[] array)
        {
            for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array.Length; j++)
                (array[i], array[j]) = (array[j], array[i]);
        }
    }
}