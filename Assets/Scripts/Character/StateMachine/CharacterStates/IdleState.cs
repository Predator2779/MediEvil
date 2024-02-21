using System;
using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class IdleState : CharacterState
    {
        public IdleState(Person person, Animator animator, CharacterStateMachine stateMachine) : base(person, animator, stateMachine)
        {
            StateMachine = person.StateMachine;
        }

        public override void Enter()
        {
            Animation = "idle";
            base.Enter();
        }
    }
}