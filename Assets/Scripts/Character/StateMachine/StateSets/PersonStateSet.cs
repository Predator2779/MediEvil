using Character.Classes;
using Character.StateMachine.CharacterStates;

namespace Character.StateMachine.StateSets
{
    public class PersonStateSet
    {
        public CharacterState DefaultState { get; set; }
        public IdleState IdleState { get; }
        public WalkState WalkState { get; }
        public RunState RunState { get; }
        public JumpState JumpState { get; }
        public FallState FallState { get; }
        public FallDownState FallDownState { get; }
        public RollState RollState { get; }
        public SlideState SlideState { get; }
        public DeathState DeathState { get; }

        public PersonStateSet(Person person)
        {
            IdleState = new IdleState(person);
            WalkState = new WalkState(person);
            RunState = new RunState(person);
            JumpState = new JumpState(person);
            RollState = new RollState(person);
            FallState = new FallState(person);
            FallDownState = new FallDownState(person);
            SlideState = new SlideState(person);
            DeathState = new DeathState(person);

            DefaultState = IdleState;
        }
    }
}