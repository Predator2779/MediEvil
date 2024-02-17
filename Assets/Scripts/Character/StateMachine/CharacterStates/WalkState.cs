using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        private readonly CharacterMovement _movement;
        public WalkState(Person person) : base(person)
        {
        }
        
        public override void Enter()
        {
            Animation = "walk";
            base.Enter();
        }

        public override void Execute()
        {
            base.Execute();
            Walk();
        }

        protected virtual void Walk()
        {
            Person.SpriteRenderer.flipX = Person.Movement.Direction.x < 0;
            Person.Movement.Walk();
        }
    }
}