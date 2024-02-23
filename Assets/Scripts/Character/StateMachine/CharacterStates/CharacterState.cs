using Character.Classes;
using Character.Movement;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected Animator Animator { get; }
        protected CharacterMovement Movement { get; }
        protected CharacterStateMachine StateMachine { get; }
        
        protected string Animation { get; set; }

        public bool IsCompleted = true;
        
        protected CharacterState(Person person)
        {
            Person = person;
            Animator = person.Animator;
            Movement = person.Movement;
            StateMachine = person.StateMachine;
        }

        public virtual void Enter()
        {
            Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);
        }

        public virtual void Execute()
        {
        }

        protected void SafetyCompleting() => IsCompleted = AnimationCompleted();

        public bool AnimationCompleted()
        {
            var animInfo = Animator.GetCurrentAnimatorStateInfo(0);
            return animInfo.normalizedTime >= animInfo.length + GlobalConstants.AnimDelay;
        }

        public virtual void Exit()
        {
            Animator.StopPlayback();
        }
    }
}