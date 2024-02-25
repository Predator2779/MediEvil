using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : WalkState
    {
        public RollState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(
            person, spriteRenderer, animator, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            if (Movement.IsGrounded()) Movement.Roll();
        }

        public override void Execute() => SafetyCompleting();
        public override void FixedExecute() {}
    }
}