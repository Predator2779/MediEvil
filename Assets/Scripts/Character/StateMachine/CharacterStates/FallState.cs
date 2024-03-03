using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class FallState : CharacterState
    {
        public FallState(Person person) : base(person)
        {
            Animation = "fall";
        }

        public override void Enter()
        {
            IsCompleted = false;
            base.Enter();
        }

        public override void Execute()
        {
            if (!Person.Movement.IsGrounded()) return;
            IsCompleted = true;
        }
    }
}