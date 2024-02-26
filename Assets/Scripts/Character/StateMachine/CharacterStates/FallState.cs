using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class FallState : CharacterState
    {
        public FallState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer,
            Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator,
            movement)
        {
            Animation = "fall";
        }

        public override void Enter()
        {
            if (Movement.IsGrounded()) return;
            IsCompleted = false;

            base.Enter();
        }

        public override void Execute()
        {
            if (!Movement.IsGrounded()) return;
            IsCompleted = true;
        }
    }
}