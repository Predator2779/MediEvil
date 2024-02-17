using System;
using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Person person) : base(person)
        {
        }

        public override void Enter()
        {
            Animation = "Attack";
            base.Enter();
        }
    }
}