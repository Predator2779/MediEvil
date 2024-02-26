using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        public WalkState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer, Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator, movement)
        {
            Animation = "walk";
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            base.Enter();
        }

        public override void Execute()
        {
            SpriteRenderer.flipX = Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            if (Movement.IsGrounded()) Movement.Walk();
        }
    }
}