using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneRotationElement : MonoBehaviour
    {
        [SerializeField] private BasementGramophoneVelocity _velocity;
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _rotateAxis;

        private void Update()
        {
            if (_velocity.AngularVelocity < 0.0001f)
                return;
            
            _transform.Rotate(_rotateAxis * (_velocity.AngularVelocity * Time.deltaTime));
        }
    }
}