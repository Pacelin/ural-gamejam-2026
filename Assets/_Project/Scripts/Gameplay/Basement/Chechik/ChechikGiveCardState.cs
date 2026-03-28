using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class ChechikGiveCardState : ChechikState
    {
        private static readonly int IsGive = Animator.StringToHash("is_give");

        public ChechikGiveCardState(ChechikAgent agent, ChechikStateMachine stateMachine) : base(agent, stateMachine)
        {
        }

        public override void OnEnterState()
        {
            Agent.MovementService.BlockControls();
            Agent.Animator.SetBool(IsGive, true);
        }

        public override void OnExitState()
        {
            Agent.MovementService.UnblockControls();
            Agent.Animator.SetBool(IsGive, false);
        }

        public override void OnAnimatorMove()
        {
            Agent.ApplyAnimatorRootMotion();
        }

        public override void OnUpdate()
        {
            if (Agent.FloppyPickup)
                return;

            StateMachine.SwitchState(new ChechikRotateToState(Agent, StateMachine,
                Agent.GetLookAt(Agent.SlotPoint),
                new ChechikMoveToState(Agent, StateMachine,
                    Agent.SlotPoint.position,
                    new ChechikRotateToState(Agent, StateMachine,
                        Agent.SlotPoint.rotation,
                        new ChechikPointingSlotState(Agent, StateMachine)))
            ));
        }
    }
}