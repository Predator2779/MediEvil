using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public CharacterMovement Movement { get; set; }

        public JumpState(Person person, Animator animator, CharacterStateMachine stateMachine) : base(person, animator, stateMachine)
        {
            Movement = person.Movement;
        }

        public override void Enter()
        {
            Animation = "jump";
            base.Enter();
            Movement.Jump();
        }

        public override void Execute()
        {
            if (Movement.IsGrounded()) Exit();
            else StateMachine.ChangeState(StateMachine.FallState);
        }
    }
}