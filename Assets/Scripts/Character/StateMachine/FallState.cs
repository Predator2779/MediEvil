using Character.Classes;
using Character.Movement;
using Character.StateMachine.CharacterStates;

namespace Character.StateMachine
{
    public class FallState : CharacterState
    {
        public FallState(Person person) : base(person)
        {
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