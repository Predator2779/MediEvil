using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public JumpState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(person, spriteRenderer, animator, animName)
        {
        }

        public override void Enter()
        {          
            if (!Movement.IsGrounded()) return;
            
            base.Enter();
            Movement.Jump();
        }

        public override void Execute()
        {
            if (Movement.IsGrounded()) 
                Person.StateMachine.ExitState();
            else StateMachine.ChangeState(StateMachine.FallState);
        }
    }
}