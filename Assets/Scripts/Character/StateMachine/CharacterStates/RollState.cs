using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : CharacterState
    {
        private CharacterMovement Movement { get; } 
        public RollState(Person person, Animator animator, CharacterStateMachine stateMachine) : base(person, animator, stateMachine)
        {
            Movement = person.Movement;
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            
            Animation = "roll";
            base.Enter();
        }

        public override void Execute()
        {
            Movement.Roll();
            base.Execute();
        }
    }
}