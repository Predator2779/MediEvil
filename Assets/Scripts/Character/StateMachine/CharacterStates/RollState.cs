using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : CharacterState
    {
        private SpriteRenderer SpriteRenderer { get; }

        public RollState(Person person) : base(person)
        {
            SpriteRenderer = person.SpriteRenderer;
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            
            Animation = "roll";
            base.Enter();
        }

        public override void Execute()
        {
            SafetyCompleting();
            SpriteRenderer.flipX = Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            Movement.Roll();
        }
    }
}