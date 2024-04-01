using System.Threading.Tasks;
using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }
        protected string Animation { get; set; }

        public bool IsCooldown;
        public bool IsCompleted = true;

        protected CharacterState(Person person)
        {
            Person = person;
        }

        public virtual bool CanEnter() => true; 
        public virtual void Enter() => 
            Person.Animator.CrossFade(Animation, GlobalConstants.SpeedCrossfadeAnim);

        public virtual void Execute() {}
        public virtual void FixedExecute() => ChangingIndicators();
        protected void SafetyCompleting() => IsCompleted = AnimationCompleted();
        public virtual void Exit() => Person.Animator.StopPlayback();

        protected void CooldownControl()
        {
            if (Person.Stamina.CanUse || IsCooldown) return;
            IsCooldown = true;
            Task.Delay(Person.Config.StaminaRestoreDelay).ContinueWith(_ => IsCooldown = false);
        }
        
        protected bool AnimationCompleted()
        {
            var animInfo = Person.Animator.GetCurrentAnimatorStateInfo(0);
            return animInfo.normalizedTime >= animInfo.length + GlobalConstants.AnimDelay;
        }

        protected virtual void ChangingIndicators()
        {
            if (Person.Stamina.CanRestore()) Person.Stamina.Increase(Person.Config.StaminaRecovery);
        }
    }
}