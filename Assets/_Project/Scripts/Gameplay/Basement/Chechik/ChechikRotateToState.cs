using UnityEngine;

namespace Project.Gameplay.Basement
{
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
            var transform = Agent.Transform;

            var newRotation =
                Quaternion.RotateTowards(transform.rotation, _targetRotation, Agent.RotateSpeed * Time.deltaTime);
            bool isFinish = newRotation == _targetRotation;
            transform.rotation = newRotation;
            Agent.ApplyAnimatorRootMotion();

            if (isFinish)
                StateMachine.SwitchState(_nextState);
        }

        public override void OnExitState()
        {
        }

        public override void OnUpdate()
        {
        }
    }
}