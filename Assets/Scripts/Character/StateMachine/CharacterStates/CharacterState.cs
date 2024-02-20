﻿using Character.Classes;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected Animator Animator { get; set; }
        protected CharacterStateMachine StateMachine { get; }
        protected string Animation { get; set; }


        protected CharacterState(Person person)
        {
            Person = person;
            Animator = person.Animator;
            StateMachine = person.StateMachine;
        }

        public virtual void Enter()
        {
            Animator.StopPlayback();
            Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);
        }

        public virtual void Execute()
        {
            var stateInfo = Animator.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName(Animation)) Exit();
        }

        public virtual void Exit()
        {
            Animator.StopPlayback();
            StateMachine.ExitState();
        }
    }
}