using TMPro;

namespace Project.Gameplay.Basement
{
    public class ChechikStateMachine
    {
        private ChechikState _currentState;
        
        public void Run(ChechikState state)
        {
            _currentState = state;
            _currentState.OnEnterState();
        }

        public void Stop()
        {
            _currentState.OnExitState();
            _currentState = null;
        }

        public void Update()
        {
            _currentState?.OnUpdate();
        }

        public void OnAnimatorMove()
        {
            _currentState?.OnAnimatorMove();
        }
        
        public void SwitchState(ChechikState state)
        {
            _currentState?.OnExitState();
            _currentState = state;
            _currentState.OnEnterState();
        }
    }
}