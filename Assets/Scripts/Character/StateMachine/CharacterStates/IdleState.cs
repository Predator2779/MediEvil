using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(person, spriteRenderer, animator, animName)
        {
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded) return;
            base.Enter();
        }
    }
}