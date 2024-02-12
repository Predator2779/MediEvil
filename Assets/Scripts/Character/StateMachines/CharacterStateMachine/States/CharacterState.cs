using UnityEngine;

namespace Character.StateMachines.CharacterStateMachine.States
{
    public class CharacterState : State<CharacterStates>
    {
        protected Person _person;
        protected Animator _animator;
        protected int _animHash;

        protected CharacterState(Person person, int animHash)
        {
            _person = person;
            _animator = person.GetAnimator();
            _animHash = animHash;
        }
        
        public override void Enter(StateContext<CharacterStates> context)
        {
            _animator.CrossFade(_animHash, 0.1f);
        }

        public override void Execute()
        {
            _animator.Play(_animHash);
        }

        public override void Exit()
        {
            _animator.StopPlayback();
        }
    }
}