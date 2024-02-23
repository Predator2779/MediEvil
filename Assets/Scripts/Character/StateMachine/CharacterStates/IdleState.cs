using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person) : base(person)
        {
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            
            Debug.Log("Idle...");
            Animation = "idle";
            base.Enter();
        }
    }
}