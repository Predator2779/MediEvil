using Character.Classes;
using Character.Movement;
using Character.StateMachine.CharacterStates;
using UnityEngine;

namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        public CharacterState CurrentState { get; private set; }
        public IdleState IdleState { get; }
        public WalkState WalkState { get; }
        public RunState RunState { get; }
        public JumpState JumpState { get; }
        public FallState FallState { get; }
        public RollState RollState { get; }

        private readonly Person _person;
        private readonly CharacterState _defaultState;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Animator _animator;
        private readonly CharacterMovement _movement;

        public CharacterStateMachine(Person person, SpriteRenderer spriteRenderer, Animator animator, CharacterMovement movement)
        {
            _person = person;
            _spriteRenderer = spriteRenderer;
            _animator = animator;
            _movement = movement;

            IdleState = new IdleState(_person, this, _spriteRenderer, _animator, _movement);
            WalkState = new WalkState(_person, this, _spriteRenderer, _animator, _movement);
            RunState = new RunState(_person, this, _spriteRenderer, _animator, _movement);
            JumpState = new JumpState(_person, this, _spriteRenderer, _animator, _movement);
            RollState = new RollState(_person, this, _spriteRenderer, _animator, _movement);
            FallState = new FallState(_person, this, _spriteRenderer, _animator, _movement);

            _defaultState = IdleState;
            CurrentState = _defaultState;
        }

        public void ChangeState(CharacterState newState)
        {
            if (CurrentState == newState || !CurrentState.IsCompleted) return;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void ExecuteState() => CurrentState.Execute();
        public void FixedExecute() => CurrentState.FixedExecute();
        public void ExitState() => ChangeState(_defaultState);
    }
}