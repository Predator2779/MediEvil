using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        private bool _canJump = true;
        public JumpState(Person person, string animName) : base(person, animName)
        {
        }

        public override void FixedExecute()
        {
            if (!_canJump || !Movement.IsGrounded) return;
            
            _canJump = false;
            Movement.Jump();
        }

        public override void Exit()
        {
            _canJump = true;
            base.Exit();
        }
    }
}