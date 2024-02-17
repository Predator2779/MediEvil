﻿using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected string Animation { get; set; }

        protected CharacterState(Person person)
        {
            Person = person;
        }
        
        public virtual void Enter()
        {
            Person.Animator.StopPlayback();
            Person.Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);
        }

        public virtual void Execute()
        {
            var stateInfo = Person.Animator.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName(Animation)) Exit(); 
        }

        public virtual void Exit()
        {
            Person.Animator.StopPlayback();
            Person.StateMachine.ExitState();
        }
    }
}