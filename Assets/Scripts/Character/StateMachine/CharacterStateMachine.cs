using Character.Classes;
using Character.StateMachine.CharacterStates;

namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        private CharacterState CurrentState { get; set; }
        public IdleState IdleState { get; }
        public WalkState WalkState { get; }
        public RunState RunState { get; }
        public JumpState JumpState { get; }
        public FallState FallState { get; }
        public FallDown FallDownState { get; }
        public RollState RollState { get; }
        public SlideState SlideState { get; }
        public DeathState DeathState { get; }

        private readonly Person _person;

        public CharacterStateMachine(Person person)
        {
            _person = person;

            IdleState = new IdleState(_person);
            WalkState = new WalkState(_person);
            RunState = new RunState(_person);
            JumpState = new JumpState(_person);
            RollState = new RollState(_person);
            FallState = new FallState(_person);
            FallDownState = new FallDown(_person);
            SlideState = new SlideState(_person);
            DeathState = new DeathState(_person);

            CurrentState = IdleState;
        }

        public void ChangeState(CharacterState newState)
        {
            if (CurrentState == newState || !CurrentState.IsCompleted || newState.IsCooldown) return;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void ForcedChangeState(CharacterState newState)
        {
            if (CurrentState == newState) return;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        
        public void ExecuteState() => CurrentState.Execute();
        public void FixedExecute() => CurrentState.FixedExecute();
    }
}