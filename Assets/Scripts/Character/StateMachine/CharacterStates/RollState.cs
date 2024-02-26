using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : WalkState
    {
        public RollState(Person person) : base(person)
        {
            Animation = "roll";
        }

        public override void Enter()
        {
            base.Enter();
            if (Person.Movement.IsGrounded()) Person.Movement.Roll();
        }

        public override void Execute() => SafetyCompleting();

        public override void FixedExecute()
        {
        }
    }
}