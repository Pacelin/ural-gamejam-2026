using DG.Tweening;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementGramophoneIgla : MonoBehaviour
    {
        public bool IsActive => _isActive;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _defaultPoint;
        [SerializeField] private Transform _activePoint;
        [SerializeField] private float _rotateDuration = 0.3f;
        
        private bool _isActive;

        private void OnDestroy()
        {
            DOTween.Kill(_transform);
        }

        public void Switch()
        {
            DOTween.Kill(_transform);
            if (_isActive)
            {
                _transform.DORotateQuaternion(_defaultPoint.rotation, _rotateDuration);
                _isActive = false;
            }
            else
            {
                _transform.DORotateQuaternion(_activePoint.rotation, _rotateDuration);
                _isActive = true;
            }
        }
    }
}