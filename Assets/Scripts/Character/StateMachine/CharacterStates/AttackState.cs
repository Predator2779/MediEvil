using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Person person, CharacterStateMachine stateMachine, SpriteRenderer spriteRenderer, Animator animator, CharacterMovement movement) : base(person, stateMachine, spriteRenderer, animator, movement)
        {
            Animation = "attack";
        }
    }
}