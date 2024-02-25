using Character.Classes;
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

        public CharacterStateMachine(Person person, SpriteRenderer spriteRenderer, Animator animator)
        {
            _person = person;
            _spriteRenderer = spriteRenderer;
            _animator = animator;
            
            IdleState = new IdleState(_person, _spriteRenderer, _animator, "idle");
            WalkState = new WalkState(_person, _spriteRenderer, _animator, "walk");
            RunState = new RunState(_person, _spriteRenderer, _animator, "run");
            JumpState = new JumpState(_person, _spriteRenderer, _animator, "jump");
            RollState = new RollState(_person, _spriteRenderer, _animator, "roll");
            FallState = new FallState(_person, _spriteRenderer, _animator, "fall");

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