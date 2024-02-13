using Character.Movement;
using UnityEngine;

namespace Character.StateMachines.CharacterStateMachine.States
{
    public class WalkCharacterState : CharacterState
    {
        private Person _person;
        private CharacterMovement _movement;
        private SpriteRenderer _spriteRenderer;
        private Vector2 _direction;

        public WalkCharacterState(Person person, int animHash) : base(person, animHash)
        {
            _person = person;
            _movement = person.GetMovement();
            _spriteRenderer = person.GetSpriteRenderer();
            _animator = person.GetAnimator();
            _animHash = animHash;
        }

        public override void Enter(StateContext<CharacterStates> context)
        {
            base.Enter(context);
            _movement.IsWalk = true;
        }

        public override void Execute()
        {
            base.Execute();
            AnimateWalk(_movement.HorizontalDirection);
        }

        public void AnimateWalk(Vector2 direction, float animSpeed = 1)
        {
            _spriteRenderer.flipX = !(direction.x >= 0);
            _animator.SetBool("Walk", true);
            _animator.speed = animSpeed;
        }

        public override void Exit()
        {
            base.Exit();
            _movement.IsWalk = false;
        }
    }
}