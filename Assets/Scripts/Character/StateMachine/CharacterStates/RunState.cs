using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : WalkState
    {
        private SpriteRenderer SpriteRenderer { get; }
        public RunState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(person, spriteRenderer, animator, animName)
        {
        }

        public override void FixedExecute()
        {
            if (Movement.IsGrounded()) Movement.Run();
        }
    }
}