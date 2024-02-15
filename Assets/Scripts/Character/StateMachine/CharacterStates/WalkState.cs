using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        private readonly Animator _animator;
        private readonly CharacterMovement _movement;

        public WalkState(Animator animator, CharacterMovement movement) : base(animator)
        {
            _animator = animator;
            _movement = movement;
        }

        public WalkState(Person2 person, Animator animator) : base(animator)
        {
            // person.Walk();
            person.Movement.Jump();
            person.Animator.CrossFade("Jump", 0.1f);
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute()
        {
            // _movement.Walk();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}