using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        private SpriteRenderer SpriteRenderer { get; }

        public WalkState(Person person, string animName) : base(person, animName)
        {
            SpriteRenderer = person.SpriteRenderer;
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