using Character.Classes;
using Character.Movement;
using Character.StateMachine.CharacterStates;

namespace Character.StateMachine
{
    public class FallState : CharacterState
    {
        private CharacterMovement Movement { get; set; }

        public FallState(Person person) : base(person)
        {
            Movement = person.Movement;
        }

        public override void Enter()
        {
            Animation = "fall";
            base.Enter();
        }

        public override void Execute()
        {
            if (Movement.IsGrounded()) Exit();
        }
    }
}