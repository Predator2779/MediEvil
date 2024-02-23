using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        private SpriteRenderer SpriteRenderer { get; }

        public WalkState(Person person) : base(person)
        {
            SpriteRenderer = person.SpriteRenderer;
        }

        public override void Enter()
        {
            Animation = "walk";
            base.Enter();
        }

        public override void Execute()
        {
            if (!Movement.IsGrounded()) return;
            
            base.Execute();
            Walk();
        }

        private void Walk()
        {
            Debug.Log("Walking...");
            SpriteRenderer.flipX = Movement.Direction.x < 0;
            Movement.Walk();
        }
    }
}