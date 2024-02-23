using Character.Classes;
using Character.Movement;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        private Person Person { get; }
        private Animator Animator { get; }
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
            Debug.Log("IsCompleted: " + IsCompleted);
        }

        protected void SafetyCompleting() => IsCompleted = !Animator.GetCurrentAnimatorStateInfo(0).IsName(Animation);

        public virtual void Exit()
        {
            Animator.StopPlayback();
        }
    }
}