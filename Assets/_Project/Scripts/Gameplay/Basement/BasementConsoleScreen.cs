using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleScreen : MonoBehaviour
    {
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private Animator _animator;

        public void PlaySound(SoundEvent soundEvent)
        {
            soundEvent.PlayOneShotInPoint(_soundPoint.position);
        }
        
        public void StartAction(EBasementConsoleScreenAction action)
        {
            
        }
    }
}