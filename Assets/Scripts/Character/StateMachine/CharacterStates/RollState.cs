﻿using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : CharacterState
    {
        private SpriteRenderer SpriteRenderer { get; }

        public RollState(Person person, string animName) : base(person, animName)
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
            SafetyCompleting();
            SpriteRenderer.flipX = Movement.Direction.x < 0;
        }

        public override void FixedExecute()
        {
            if (Movement.IsGrounded) Movement.Roll();
        }
    }
}