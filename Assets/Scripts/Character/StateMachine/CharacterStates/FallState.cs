using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class FallState : CharacterState
    {
        public FallState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(person, spriteRenderer, animator, animName)
        {
        }

        public override void Enter()
        {
            if (Movement.IsGrounded()) return;
            IsCompleted = false;
            
            base.Enter();
        }

        public override void Execute()
        {
            if (!Movement.IsGrounded()) return;
            IsCompleted = true;
        }
    }
}