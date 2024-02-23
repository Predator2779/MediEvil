using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class FallState : CharacterState
    {
        public FallState(Person person, string animName) : base(person, animName)
        {
        }

        public override void Enter()
        {
            if (Movement.IsGrounded) return;
            IsCompleted = false;
            
            base.Enter();
        }

        public override void FixedExecute()
        {
            if (!Movement.IsGrounded) return;
            IsCompleted = true;
        }
    }
}