﻿using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        public WalkState(Person person) : base(person)
        {
            Animation = "walk";
        }

        public override void Enter()
        {
            if (!Person.Movement.IsGrounded()) return;
            base.Enter();
        }

        public override void Execute()
        {
            Person.SpriteRenderer.flipX = Person.Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            if (Person.Movement.IsGrounded()) Person.Movement.Walk();
        }
    }
}