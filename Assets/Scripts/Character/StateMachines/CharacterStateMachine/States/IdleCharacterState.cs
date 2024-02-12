using UnityEngine;

namespace Character.StateMachines.CharacterStateMachine.States
{
    public class IdleCharacterState : CharacterState
    {
        public IdleCharacterState(Person person, int animHash) : base(person, animHash)
        {
            _person = person;
            _animHash = animHash;
        }
    }
}