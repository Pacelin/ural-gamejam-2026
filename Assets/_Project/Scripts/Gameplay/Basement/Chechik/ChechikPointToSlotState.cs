using UnityEngine;

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

        public override void OnExitState()
        {
            Agent.Animator.SetBool(IsPointing, false);
        }

        public override void OnAnimatorMove()
        {
        }

        public override void OnUpdate()
        {
            if (Agent.KeyPickup)
                return;
            
            StateMachine.SwitchState(
                new ChechikRotateToState(Agent, StateMachine,
                    Agent.GetLookAt(Agent.WaitAtPureBloodPoint),
                    new ChechikMoveToState(Agent, StateMachine,
                        Agent.WaitAtPureBloodPoint.position,
                        new ChechikRotateToState(Agent, StateMachine,
                            Agent.WaitAtPureBloodPoint.rotation,
                            new ChechikIdleState(Agent, StateMachine))))
            );
        }
    }
}