using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Person person, SpriteRenderer spriteRenderer, Animator animator, string animName) : base(person, spriteRenderer, animator, animName)
        {
        }
    }
}