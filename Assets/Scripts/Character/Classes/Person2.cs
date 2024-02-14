using Character.CharacterControllers;
using Character.Movement;
using Character.StateMachine;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(Controller))]
    public class Person2 : MonoBehaviour
    {
        [field: SerializeField] public CharacterStateMachine StateMachine { get; protected set; }
        [field: SerializeField] public CharacterMovement Movement { get; }
        [field: SerializeField] public Controller Controller { get; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; }
        [field: SerializeField] public Animator Animator { get; }
        // [field: SerializeField] public IHealth Health { get; }

        private void Update() => Controller.Execute();

        public void Jump()
        {
            Movement.Jump();
            Animator.CrossFade("Jump", 0.1f);
        }
        
        public void Walk() => print("Walk");
    }
}