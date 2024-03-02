﻿using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : WalkState
    {
        public RunState(Person person) : base(person)
        {
            Animation = "run";
        }
        
        public override void FixedExecute()
        {
            Person.Movement.Run();
            ChangingIndicators();
        }

        protected override void ChangingIndicators() => Person.Stamina.Decrease(Person.Data.StaminaUsage);
    }
}