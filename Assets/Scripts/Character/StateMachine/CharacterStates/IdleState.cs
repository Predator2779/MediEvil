using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person) : base(person)
        {
            Animation = "idle";
        }

        public override void Enter()
        {
            if (!Person.Movement.IsGrounded()) return;
            base.Enter();
        }
    }
}