using Character.StateMachine.CharacterStates;

namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        private CharacterState _currentState;

        public void ChangeState(CharacterState newCharacterState)
        {
            _currentState?.Exit();
            _currentState = newCharacterState;
            _currentState.Enter();
        }

        public void ExecuteState() => _currentState.Execute();
    }
}