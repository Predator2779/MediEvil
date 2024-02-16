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
            Console.WriteLine("Entering Idle State");
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            Console.WriteLine("Exiting Idle State");
        }
    }
}