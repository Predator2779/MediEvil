using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : CharacterState
    {
        private SpriteRenderer SpriteRenderer { get; }
        public RunState(Person person) : base(person)
        {
            SpriteRenderer = person.SpriteRenderer;
        }

        public override void Enter()
        {
            Animation = "run";
            base.Enter();
        }

        public override void Execute()
        {
            SpriteRenderer.flipX = Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            if (Movement.IsGrounded()) Movement.Run();
        }
    }
}