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
        public JumpState JumpState { get; set; }
        public FallState FallState { get; set; }
        public RollState RollState { get; set; }

        private readonly Person _person;
        private readonly CharacterState _defaultState;

        public CharacterStateMachine(Person person, CharacterState defaultState)
        {
            _person = person;
            
            IdleState = new IdleState(_person);
            WalkState = new WalkState(_person);
            JumpState = new JumpState(_person);

            _defaultState = defaultState;
        }

        public void ChangeState(CharacterState newState)
        {
            if (CurrentState == newState) return;
            
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void ExecuteState() => CurrentState.Execute();
        public void ExitState() => ChangeState(_defaultState);
    }
}