using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : CharacterState
    {
        public RollState(Person person) : base(person)
        {
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            
            Animation = "roll";
            base.Enter();
        }

        public override void Execute()
        {
            SafetyCompleting();

            Debug.Log("Rollin...");
            Movement.Roll();
            base.Execute();
        }
    }
}