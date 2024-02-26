using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : WalkState
    {
        public RunState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer,
            Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator,
            movement)
        {
            Animation = "run";
        }

        public override void FixedExecute()
        {
            if (Movement.IsGrounded()) Movement.Run();
        }
    }
}