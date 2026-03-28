using Project.Gameplay.Interactables;
using Project.Gameplay.Movement;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class ChechikGiveCardState : ChechikState
    {
        private static readonly int IsPointing = Animator.StringToHash("is_pointing");

        public ChechikGiveCardState(ChechikAgent agent, ChechikStateMachine stateMachine) : base(agent, stateMachine)
        {
        }

        public override void OnEnterState()
        {
            Agent.MovementService.BlockControls();
            Agent.Animator.SetBool(IsPointing, true);
        }

        public override void OnExitState()
        {
            Agent.MovementService.UnblockControls();
            Agent.Animator.SetBool(IsPointing, false);
        }

        public override void OnUpdate()
        {
            //if (Agent.FloppyTaken)
        }
    }
    
    public class ChechikRotateToState : ChechikState
    {
        private static readonly int IsPointing = Animator.StringToHash("is_pointing");
        private readonly ChechikState _nextState;
        
        public ChechikRotateToState(ChechikAgent agent, ChechikStateMachine stateMachine,
            ChechikState nextState) : base(agent, stateMachine)
        {
            _nextState = nextState;
        }

        public override void OnEnterState()
        {
            Agent.Animator.SetBool(IsPointing, true);
        }

        public override void OnExitState()
        {
            Agent.Animator.SetBool(IsPointing, false);
        }

        public override void OnUpdate()
        {
        }
    }
    
    public class ChechikAgent : NotInteractableObject
    {
        public bool FloppyTaken => _floppyPickup;
        public bool KeyTaken => _keyPickup;
        public MovementService MovementService { get; private set; }
        public Transform Transform => _transform;
        public Animator Animator => _animator;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _floppyPickup;
        [SerializeField] private GameObject _keyPickup;

        private ChechikStateMachine _stateMachine;
        
        private void OnAnimatorMove()
        {
            _transform.position += _animator.deltaPosition;
            _transform.rotation *= _animator.deltaRotation;
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