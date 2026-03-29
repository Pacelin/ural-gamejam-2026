using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class ChechikAgent : NotInteractableObject
    {
        public GameObject FloppyPickup => _floppyPickup;
        public GameObject KeyPickup => _keyPickup;
        public float AppearCallDelay => _appearCallDelay;
        public string AppearText => _appearText;
        public SoundEvent AppearSound => _appearSound;
        public MovementService MovementService { get; private set; }
        public Transform Transform => _transform;
        public Animator Animator => _animator;
        public Transform SlotPoint => _slotPoint;
        public Transform WaitAtPureBloodPoint => _waitAtPureBloodPoint;

        public float RotateSpeed => _rotateSpeed;
        public float StoppingDistance => _stoppingDistance;

        [SerializeField] private float _appearCallDelay;
        [SerializeField] private string _appearText;
        [SerializeField] private SoundEvent _appearSound;
        [Space]
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _floppyPickup;
        [SerializeField] private GameObject _keyPickup;
        [SerializeField] private Transform _slotPoint;
        [SerializeField] private Transform _waitAtPureBloodPoint;
        [SerializeField] private float _rotateSpeed = 360;
        [SerializeField] private float _stoppingDistance = 0.05f;

        private ChechikStateMachine _stateMachine;

        public Quaternion GetLookAt(Transform point)
        {
            var currentPosition = _transform.position;
            var targetPosition = point.position;
            var vector = (targetPosition - currentPosition).normalized;
            return Quaternion.LookRotation(vector, Vector3.up);
        }
        
        public Quaternion GetLookAt(Vector3 point)
        {
            var currentPosition = _transform.position;
            var targetPosition = point;
            var vector = (targetPosition - currentPosition).normalized;
            return Quaternion.LookRotation(vector, Vector3.up);
        }
        
        private void OnAnimatorMove()
        {
            _stateMachine.OnAnimatorMove();
        }

        protected override void Initialize(IObjectResolver resolver)
        {
            MovementService = resolver.Resolve<MovementService>();
            _stateMachine = new ChechikStateMachine();
            _stateMachine.Run(new ChechikGiveCardState(this, _stateMachine));
        }

        private void OnDestroy()
        {
            _stateMachine.Stop();
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}