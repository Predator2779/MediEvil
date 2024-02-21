using System;
using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Person person, Animator animator, CharacterStateMachine stateMachine) : base(person, animator, stateMachine)
        {
        }

        public override void Enter()
        {
            Animation = "Attack";
            base.Enter();
        }
    }
}