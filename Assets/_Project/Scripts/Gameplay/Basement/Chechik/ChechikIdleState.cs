namespace Project.Gameplay.Basement
{
    public class ChechikIdleState : ChechikState
    {
        public ChechikIdleState(ChechikAgent agent, ChechikStateMachine stateMachine) : base(agent, stateMachine)
        {
        }

        public override void OnEnterState() { }
        public override void OnUpdate() { }

        public override void OnAnimatorMove()
        {
            Agent.ApplyAnimatorRootMotion();
        }
        public override void OnExitState() { }
    }
}