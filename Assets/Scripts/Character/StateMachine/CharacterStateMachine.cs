using Character.Classes;
using Character.StateMachine.CharacterStates;

namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        public CharacterState CurrentState { get; private set; }
        public IdleState IdleState { get; }
        public WalkState WalkState { get; }
        public RunState RunState { get; }
        public JumpState JumpState { get; }
        public FallState FallState { get; }
        public RollState RollState { get; }

        private readonly Person _person;
        private readonly CharacterState _defaultState;

        public CharacterStateMachine(Person person)
        {
            _person = person;
            
            IdleState = new IdleState(_person);
            WalkState = new WalkState(_person);
            RunState = new RunState(_person);
            JumpState = new JumpState(_person);
            RollState = new RollState(_person);

            _defaultState = IdleState;
            CurrentState = _defaultState;
        }

        public void ChangeState(CharacterState newState)
        {
            if (CurrentState == newState || !CurrentState.IsCompleted) return;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void ExecuteState() => CurrentState.Execute();

        public void FixedExecute() => CurrentState.FixedExecute();

        public void ExitState() => ChangeState(_defaultState);
    }
}