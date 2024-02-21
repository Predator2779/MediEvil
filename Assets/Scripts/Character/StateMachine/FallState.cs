using Character.Classes;
using Character.Movement;
using Character.StateMachine.CharacterStates;
using UnityEngine;

namespace Character.StateMachine
{
    public class FallState : CharacterState
    {
        private CharacterMovement Movement { get; set; }

        public FallState(Person person, Animator animator, CharacterStateMachine stateMachine) : base(person, animator, stateMachine)
        {
            Movement = person.Movement;
        }

        public override void Enter()
        {
            Animation = "fall";
            base.Enter();
        }

        public override void Execute()
        {
            if (Movement.IsGrounded()) Exit();
        }
    }
}