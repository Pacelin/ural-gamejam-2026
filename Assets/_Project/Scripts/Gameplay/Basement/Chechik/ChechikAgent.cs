using Project.Gameplay.Interactables;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class ChechikPointToSlotState : ChechikState
    {
        private static readonly int IsPointing = Animator.StringToHash("is_pointing");

        public ChechikPointToSlotState(ChechikAgent agent, ChechikStateMachine stateMachine) : base(agent, stateMachine)
        {
        }

        public override void OnEnterState()
        {
            Agent.Animator.SetBool(IsPointing, true);
        }

        public override void OnAnimatorMove()
        {
            throw new System.NotImplementedException();
        }

        public override void OnExitState()
        {
            Agent.Animator.SetBool(IsPointing, false);
        }

        public override void OnUpdate()
        {
            //if (Agent.FloppyTaken)
        }
    }
    
    public class ChechikMoveToState : ChechikState
    {
        private static readonly int IsMove = Animator.StringToHash("is_run");
        private readonly ChechikState _nextState;
        private readonly Vector3 _targetPosition;

        public ChechikMoveToState(ChechikAgent agent, ChechikStateMachine stateMachine, 
            Vector3 worldPosition,
            ChechikState nextState) : base(agent, stateMachine)
        {
            _nextState = nextState;
            _targetPosition = worldPosition;
        }

        public override void OnEnterState()
        {
            Agent.Animator.SetBool(IsMove, true);
        }

        public override void OnAnimatorMove()
        {
            throw new System.NotImplementedException();
        }

        public override void OnExitState()
        {
            Agent.Animator.SetBool(IsMove, false);
        }

        public override void OnUpdate()
        {
            //if (Agent.FloppyTaken)
        }
    }

    public class ChechikPointingSlotState : ChechikState
    {
        private static readonly int IsPointing = Animator.StringToHash("is_pointing");

        public ChechikPointingSlotState(ChechikAgent agent, ChechikStateMachine stateMachine) : base(agent, stateMachine)
        {
        }

        public override void OnEnterState()
        {
            Agent.Animator.SetBool(IsPointing, true);
        }

        public override void OnExitState()
        {
            Agent.Animator.SetBool(IsPointing, false);
        }

        public override void OnAnimatorMove()
        {
            Agent.ApplyAnimatorRootMotion();
        }

        public override void OnUpdate()
        {
            if (Agent.KeyPickup)
                return;

        }
    }
    
    public class ChechikRotateToState : ChechikState
    {
        private readonly ChechikState _nextState;
        private readonly Quaternion _targetRotation;
        
        public ChechikRotateToState(ChechikAgent agent, ChechikStateMachine stateMachine,
            Quaternion targetRotation, ChechikState nextState) : base(agent, stateMachine)
        {
            _nextState = nextState;
            _targetRotation = targetRotation;
        }

        public override void OnEnterState()
        {
        }

        public override void OnAnimatorMove()
        {
            var animator = Agent.Animator;
            var transform = Agent.Transform;

            var newRotation =
                Quaternion.RotateTowards(transform.rotation, _targetRotation, Agent.RotateSpeed * Time.deltaTime);
            newRotation *= animator.deltaRotation;
            
        }

        public override void OnExitState()
        {
        }

        public override void OnUpdate()
        {
        }
    }
    
    public class ChechikAgent : NotInteractableObject
    {
        public GameObject FloppyPickup => _floppyPickup;
        public GameObject KeyPickup => _keyPickup;
        public MovementService MovementService { get; private set; }
        public Transform Transform => _transform;
        public Animator Animator => _animator;
        public Transform SlotPoint => _slotPoint;
        public Transform WaitAtPureBloodPoint => _waitAtPureBloodPoint;

        public float RotateSpeed => _rotateSpeed;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _floppyPickup;
        [SerializeField] private GameObject _keyPickup;
        [SerializeField] private Transform _slotPoint;
        [SerializeField] private Transform _waitAtPureBloodPoint;
        [SerializeField] private float _rotateSpeed = 360;

        private ChechikStateMachine _stateMachine;

        public Quaternion GetLookAt(Transform point)
        {
            var currentPosition = _transform.position;
            var targetPosition = point.position;
            var vector = (targetPosition - currentPosition).normalized;
            return Quaternion.LookRotation(vector, Vector3.up);
        }
        
        public void ApplyAnimatorRootMotion()
        {
            _transform.position += _animator.deltaPosition;
            _transform.rotation *= _animator.deltaRotation;
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