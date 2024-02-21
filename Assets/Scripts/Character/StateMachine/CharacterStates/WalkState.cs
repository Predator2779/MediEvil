using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        private CharacterMovement Movement { get; }

        public WalkState(Person person, Animator animator, CharacterStateMachine stateMachine) : base(person, animator, stateMachine)
        {
            Movement = person.Movement;
        }
        
        public override void Enter()
        {
            Animation = "walk";
            base.Enter();
        }

        public override void Execute()
        {
            base.Execute();
            Walk();
        }

        protected virtual void Walk()
        {
            Person.SpriteRenderer.flipX = Person.Movement.Direction.x < 0;
            Person.Movement.Walk();
        }
    }
}