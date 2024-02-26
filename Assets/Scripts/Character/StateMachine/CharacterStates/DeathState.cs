using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class DeathState : CharacterState
    {
        public DeathState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer,
            Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer,
            animator, movement)
        {
            Animation = "death";
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("You Died.");
        }

        public override void Execute() => SafetyCompleting();

        public override void Exit()
        {
            base.Exit();

            if (AnimationCompleted()) Person.Die();
        }
    }
}