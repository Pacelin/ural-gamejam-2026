using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementPoint : MonoBehaviour
    {
        public MovementPoint RightPoint => _rightPoint;
        public MovementPoint LeftPoint => _leftPoint;
        public MovementPoint BackPoint => _backPoint;

        public IReadOnlyList<GameObject> ActiveWhenOnPoint => _activeWhenOnPoint;
        
        [SerializeField] private MovementPoint _rightPoint;
        [SerializeField] private MovementPoint _leftPoint;
        [SerializeField] private MovementPoint _backPoint;
        [SerializeField] private GameObject[] _activeWhenOnPoint;

        private void Awake()
        {
            foreach (var obj in _activeWhenOnPoint)
                obj.SetActive(false);
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var selectedGo = UnityEditor.Selection.activeGameObject;
            if (selectedGo)
            {
                var selectedPoint = selectedGo.GetComponent<MovementPoint>();
                if (selectedPoint &&
                    (selectedPoint._leftPoint == this ||
                     selectedPoint._rightPoint == this ||
                     selectedPoint._backPoint == this))
                {
                    Gizmos.color = Color.yellow;
                }
            }
            
            var t = transform;
            var p = t.position;
            Gizmos.DrawSphere(p, 0.05f);
            Gizmos.DrawLine(p, p + t.forward);
        }

        private void OnDrawGizmosSelected()
        {
            var t = transform;
            var p = t.position;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(p, 0.05f);
            Gizmos.DrawLine(p, p + t.forward);
        }
#endif
    }
}