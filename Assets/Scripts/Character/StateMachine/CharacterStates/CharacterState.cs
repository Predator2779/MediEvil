using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected string Animation { get; set; }

        public bool IsCooldown = false;
        public bool IsCompleted = true;

        protected CharacterState(Person person)
        {
            Person = person;
        }

        public virtual void Enter() => Person.Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);
        public virtual void Execute() => Person.SpriteRenderer.flipX = Person.Movement.GetHorizontalVelocity() < 0;
        public virtual void FixedExecute() => ChangingIndicators();
        protected void SafetyCompleting() => IsCompleted = AnimationCompleted();
        public virtual void Exit() => Person.Animator.StopPlayback();

        protected bool AnimationCompleted()
        {
            var animInfo = Person.Animator.GetCurrentAnimatorStateInfo(0);
            return animInfo.normalizedTime >= animInfo.length + GlobalConstants.AnimDelay;
        }

        protected virtual void ChangingIndicators()
        {
            if (Person.Stamina.CanRestore()) Person.Stamina.Increase(Person.Data.StaminaRecovery);
        }
    }
}