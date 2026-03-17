using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementPoint : MonoBehaviour
    {
        public float Fov => _fov;
        public MovementPoint RightPoint => _rightPoint;
        public MovementPoint LeftPoint => _leftPoint;
        public MovementPoint BackPoint => _backPoint;

        [Range(30, 180)]
        [SerializeField] private float _fov = 60;
        [SerializeField] private MovementPoint _rightPoint;
        [SerializeField] private MovementPoint _leftPoint;
        [SerializeField] private MovementPoint _backPoint;
    }
}