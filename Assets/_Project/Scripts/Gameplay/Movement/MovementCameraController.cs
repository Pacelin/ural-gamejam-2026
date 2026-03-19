using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementCameraController : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private CinemachineImpulseSource _impulseSource;

        private void OnDestroy() => _cameraTransform.DOKill();

        public Vector3 GetPosition() => _cameraTransform.position;
        
        public void Set(Vector3 position, Quaternion rotation)
        {
            _cameraTransform.position = position;
            _cameraTransform.rotation = rotation;
        }

        public void MakeMoveImpulse(float duration)
        {
            duration -= _impulseSource.ImpulseDefinition.TimeEnvelope.AttackTime +
                        _impulseSource.ImpulseDefinition.TimeEnvelope.DecayTime;
            _impulseSource.ImpulseDefinition.TimeEnvelope.SustainTime = Mathf.Max(0, duration);
            _impulseSource.GenerateImpulse();
        }
        
        public UniTask MoveTo(Vector3 position, Quaternion rotation, float duration,
            CancellationToken cancellationToken)
        {
            return DOTween.Sequence(_cameraTransform)
                .Append(_cameraTransform.DOMove(position, duration)
                    .SetEase(Ease.InOutQuad))
                .Join(_cameraTransform.DORotateQuaternion(rotation, duration)
                    .SetEase(Ease.OutQuad))
                .ToUniTask(cancellationToken: cancellationToken);
        }
        
        public UniTask MoveTo(Vector3 position, Quaternion rotation, float duration, Vector3 doorPosition,
            CancellationToken cancellationToken)
        {
            var halfDuration = duration / 2f;
            return DOTween.Sequence(_cameraTransform)
                .Append(_cameraTransform.DOMove(doorPosition, halfDuration)
                    .SetEase(Ease.InQuad))
                .Append(_cameraTransform.DOMove(position, halfDuration)
                    .SetEase(Ease.OutQuad))
                .Join(_cameraTransform.DORotateQuaternion(rotation, halfDuration)
                    .SetEase(Ease.InBounce))
                .ToUniTask(cancellationToken: cancellationToken);
        }
    }
}