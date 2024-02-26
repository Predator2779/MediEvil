using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : WalkState
    {
        public RollState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer, Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator, movement)
        {
            Animation = "roll";
        }

        public override void Enter()
        {
            base.Enter();
            if (Movement.IsGrounded()) Movement.Roll();
        }

        public override void Execute() => SafetyCompleting();

        public override void FixedExecute()
        {
        }
    }
}