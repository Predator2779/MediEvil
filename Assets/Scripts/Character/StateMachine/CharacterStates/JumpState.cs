using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public JumpState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer,
            Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator,
            movement)
        {
            Animation = "jump";
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