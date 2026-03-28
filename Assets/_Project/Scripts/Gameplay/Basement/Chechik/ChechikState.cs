namespace Project.Gameplay.Basement
{
    public abstract class ChechikState
    {
        protected readonly ChechikAgent Agent;
        protected readonly ChechikStateMachine StateMachine;
        
        protected ChechikState(ChechikAgent agent, ChechikStateMachine stateMachine)
        {
            Agent = agent;
            StateMachine = stateMachine;
        }

        public abstract void OnEnterState();
        public abstract void OnUpdate();
        public abstract void OnExitState();
    }
}