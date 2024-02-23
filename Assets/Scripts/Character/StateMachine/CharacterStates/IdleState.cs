using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person, string animName) : base(person, animName)
        {
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded) return;
            base.Enter();
        }
    }
}