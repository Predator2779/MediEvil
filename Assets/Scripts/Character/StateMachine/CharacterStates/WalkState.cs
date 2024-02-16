using Character.Classes;
using Character.Movement;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        private readonly CharacterMovement _movement;

        public WalkState(Person person) : base(person)
        {
            // person.Walk();
            person.Movement.Jump();
            person.Animator.CrossFade("Jump", 0.1f);

        }
        
        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute()
        {
            // _movement.Walk();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}