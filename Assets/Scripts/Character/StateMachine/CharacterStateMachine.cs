using Character.Classes;
using Character.StateMachine.CharacterStates;

namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        public CharacterState CurrentState { get; private set; }
        public IdleState IdleState { get; set; }
        public WalkState WalkState { get; set; }
        public RunState RunState { get; set; }

        private readonly Person _person;
        private readonly CharacterState _defaultState;

        public CharacterStateMachine(Person person, CharacterState defaultState)
        {
            _person = person;
            
            IdleState = new IdleState(_person);
            WalkState = new WalkState(_person);

            _defaultState = defaultState;
        }

        public void ChangeState(CharacterState newCharacterState)
        {
            if (CurrentState == newCharacterState) return;
            
            CurrentState?.Exit();
            CurrentState = newCharacterState;
            CurrentState.Enter();
        }

        public void ExecuteState() => CurrentState.Execute();
        public void ExitState() => ChangeState(_defaultState);
    }
}