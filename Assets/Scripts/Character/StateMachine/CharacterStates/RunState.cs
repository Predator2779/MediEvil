using Character.Classes;
using Character.Movement;
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
            if (!Movement.IsGrounded()) return;
            
            base.Execute();
            Run();
        }

        private void Run()
        {
            Debug.Log("Running...");
            SpriteRenderer.flipX = Movement.Direction.x < 0;
            Movement.Run();
        }
    }
}