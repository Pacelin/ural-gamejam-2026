using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class ChechikSound : MonoBehaviour
    {
        [SerializeField] private SoundEvent _soundEvent;
        
        private void Awake()
        {
            _soundEvent.PlayOneShotInPoint(transform.position);
        }
    }
}