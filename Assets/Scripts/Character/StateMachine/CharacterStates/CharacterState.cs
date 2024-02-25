using Character.Classes;
using Character.Movement;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected SpriteRenderer SpriteRenderer { get; }
        protected Animator Animator { get; }
        protected CharacterMovement Movement { get; }
        protected CharacterStateMachine StateMachine { get; }
        protected string Animation { get; }

        public bool IsCompleted = true;

        protected CharacterState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName)
        {
            Person = person;
            SpriteRenderer = spriteRenderer;
            Animator = animator;
            Movement = person.Movement;
            StateMachine = person.StateMachine;
            Animation = animName;
        }

        public virtual void Enter() => Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);
        public virtual void Execute() {}
        public virtual void FixedExecute() {}
        protected void SafetyCompleting() => IsCompleted = AnimationCompleted();
        public virtual void Exit() => Animator.StopPlayback();

        public bool AnimationCompleted()
        {
            var animInfo = Animator.GetCurrentAnimatorStateInfo(0);
            return animInfo.normalizedTime >= animInfo.length + GlobalConstants.AnimDelay;
        }
    }
}