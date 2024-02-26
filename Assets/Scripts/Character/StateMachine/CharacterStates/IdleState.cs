using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer,
            Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator,
            movement)
        {
            Animation = "idle";
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            base.Enter();
        }
    }
}