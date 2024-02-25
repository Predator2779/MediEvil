using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        public WalkState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(person, spriteRenderer, animator, animName)
        {
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded) return;
            base.Enter();
        }

        public override void Execute()
        {
            SpriteRenderer.flipX = Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            if (Movement.IsGrounded) Movement.Walk();
        }
    }
}