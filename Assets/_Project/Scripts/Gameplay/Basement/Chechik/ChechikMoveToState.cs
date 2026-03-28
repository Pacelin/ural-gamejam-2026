using UnityEngine;

namespace Project.Gameplay.Basement
{
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
            var targetRotation = Agent.GetLookAt(_targetPosition);
            var delta = Agent.Animator.deltaPosition;
            var currentPosition = Agent.Transform.position;
            var distanceToTarget = Vector3.Distance(currentPosition, _targetPosition);
            bool isOnPoint = distanceToTarget <= Agent.StoppingDistance;

            if (delta.magnitude > distanceToTarget && isOnPoint)
                delta = delta.normalized * distanceToTarget;

            Agent.Transform.position += delta;
            Agent.transform.rotation = targetRotation;

            if (isOnPoint)
                StateMachine.SwitchState(_nextState);
        }

        public override void OnExitState()
        {
            Agent.Animator.SetBool(IsMove, false);
        }

        public override void OnUpdate()
        {
        }
    }
}