using Character.Classes;
using Character.Movement;
using Input;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : WalkState
    {
        private readonly CharacterMovement _movement;

        public RunState(Person person) : base(person)
        {
        }
        
        public override void Enter()
        {
            Animation = "run";
            base.Enter();
        }
        
        protected override void Walk()
        {
            base.Walk();
            Person.Movement.Run();
        }
    }
}