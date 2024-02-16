﻿using System;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Animator person) : base(person)
        {
        }

        public override void Enter()
        {
            Console.WriteLine("Entering Attack State");
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            Console.WriteLine("Exiting Attack State");
        }
    }
}