using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneVelocity : MonoBehaviour
    {
        public float NormalizedAngularVelocity => _currentAngularVelocity / _angularVelocityClamp;
        public float AngularVelocity => _currentAngularVelocity;
        
        [SerializeField] private float _angularAcceleration;
        [SerializeField] private float _angularDeceleration;
        [SerializeField] private float _angularVelocityClamp;
        
        private float _currentAngle;
        private float _targetAngle;
        private float _currentAngularVelocity;
        
        public void PerformRotation(float angle) => 
            _targetAngle = _currentAngle + angle;

        private void Update()
        {
            if (_targetAngle > _currentAngle)
            {
                var acceleration = _angularAcceleration * Time.deltaTime;
                var newVelocity = _currentAngularVelocity + acceleration;
                _currentAngularVelocity = Mathf.Min(_angularVelocityClamp, newVelocity);
                _currentAngle += _currentAngularVelocity * Time.deltaTime;
            }
            else
            {
                var deceleration = _angularDeceleration * Time.deltaTime;
                var newVelocity = _currentAngularVelocity - deceleration;
                _currentAngularVelocity = Mathf.Max(0, newVelocity);
                _currentAngle += _currentAngularVelocity * Time.deltaTime;
            }
        }
    }
}