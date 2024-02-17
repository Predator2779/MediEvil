using System;
using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person) : base(person)
        {
        }

        public override void Enter()
        {
            Animation = "Idle";
            base.Enter();
        }
    }
}