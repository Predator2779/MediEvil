using Character.Classes;
using Character.Movement;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public CharacterMovement Movement { get; set; }

        public JumpState(Person person) : base(person)
        {
            Movement = person.Movement;
        }

        public override void Enter()
        {
            Animation = "jump";
            base.Enter();
            Movement.Jump();
        }

        public override void Execute()
        {
            if (Movement.IsGrounded()) Exit();
            else StateMachine.ChangeState(StateMachine.FallState);
        }
    }
}