using Plugins.Audio;
using Project.Gameplay.Interactables;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class SoundActivator : PuzzleActivator
    {
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _sound;

        public override void Activate()
        {
            _sound.PlayOneShotInPoint(_soundPoint.position);
        }
    }
}