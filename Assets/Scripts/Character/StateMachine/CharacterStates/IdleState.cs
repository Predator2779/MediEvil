using System;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Animator animator) : base(animator)
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