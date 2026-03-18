using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementCameraController : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;

        private void OnDestroy() => _cameraTransform.DOKill();

        public Vector3 GetPosition() => _cameraTransform.position;
        
        public void Set(Vector3 position, Quaternion rotation)
        {
            _cameraTransform.position = position;
            _cameraTransform.rotation = rotation;
        }
        
        public UniTask MoveTo(Vector3 position, Quaternion rotation, float duration,
            CancellationToken cancellationToken)
        {
            return DOTween.Sequence(_cameraTransform)
                .Append(_cameraTransform.DOMove(position, duration))
                .Join(_cameraTransform.DORotateQuaternion(rotation, duration))
                .ToUniTask(cancellationToken: cancellationToken);
        }
    }
}