using System;
using Character.StateMachines.CharacterStateMachine.States;
using UnityEngine;

namespace Character.StateMachines.CharacterStateMachine
{
    public class CharacterStateContext : StateContext<CharacterStates>
    {
        public CharacterStates CurrentState { get; protected set; }
        private State<CharacterStates> _state;
        private Person _person;

        public CharacterStateContext(Person person) => _person = person;
        
        public void Initialize() => SetState(CharacterStates.Idle);
        public void Execute() => ExecuteState();
        
        public override void SetState(CharacterStates state)
        {
            CurrentState = state;

            switch (state)
            {
                case CharacterStates.Idle:
                    _state = new IdleCharacterState(_person, Animator.StringToHash("Idle"));
                    break;
                case CharacterStates.Run:
                    _state = new WalkCharacterState(_person, Animator.StringToHash("Run"));
                    break;
                case CharacterStates.Jump:
                    break;
                case CharacterStates.Fall:
                    break;
                case CharacterStates.Roll:
                    break;
                case CharacterStates.Attack:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
        public override void EnterState() => _state.Enter(this);
        public override void ExecuteState() => _state.Execute();
        public override void ExitState() => _state.Exit();
    }

    public enum CharacterStates
    {
        Idle,
        Run,
        Jump,
        Fall,
        Roll,
        Attack
    }
}