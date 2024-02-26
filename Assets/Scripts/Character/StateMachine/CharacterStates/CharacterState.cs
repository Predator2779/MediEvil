using Character.Classes;
using Character.Movement;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected CharacterStateMachine StateMachine { get; }
        protected SpriteRenderer SpriteRenderer { get; }
        protected Animator Animator { get; }
        protected CharacterMovement Movement { get; }
        protected string Animation { get; set; }

        public bool IsCompleted = true;

        protected CharacterState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer, Animator animator, CharacterMovement movement)
        {
            Person = person;
            StateMachine = stateMachine;
            SpriteRenderer = spriteRenderer;
            Animator = animator;
            Movement = movement;
        }

        public virtual void Enter() => Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);
        public virtual void Execute() {}
        public virtual void FixedExecute() {}
        protected void SafetyCompleting() => IsCompleted = AnimationCompleted();
        public virtual void Exit() => Animator.StopPlayback();

        protected bool AnimationCompleted()
        {
            var animInfo = Animator.GetCurrentAnimatorStateInfo(0);
            return animInfo.normalizedTime >= animInfo.length + GlobalConstants.AnimDelay;
        }
    }
}