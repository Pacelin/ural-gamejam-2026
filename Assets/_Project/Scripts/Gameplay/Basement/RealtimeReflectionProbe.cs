using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class RealtimeReflectionProbe : MonoBehaviour
    {
        [SerializeField] private ReflectionProbe _reflectionProbe;
        [SerializeField] private float _cooldown;

        private float _time;
        
        private void Update()
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _reflectionProbe.RenderProbe();
                _time = _cooldown;
            }
        }
    }
}