using Character.CharacterControllers;
using Character.Movement;
using Character.StateMachine;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(Controller))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class Person2 : MonoBehaviour
    {
        [field: SerializeField] private bool IsPlayer { get; }
        [field: SerializeField] private PersonData PersonData { get; }
        [field: SerializeField] public Controller Controller { get; protected set; } // прокинуть Zenject-ом
        [field: SerializeField] public CharacterStateMachine StateMachine { get; protected set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; }
        [field: SerializeField] public CharacterMovement Movement { get; protected set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; protected set; }
        [field: SerializeField] public Animator Animator { get; protected set; }
        // [field: SerializeField] public IHealth Health { get; }

        private void Start() => Initialize();
        
        private void Update() => Controller.Execute();

        protected virtual void Initialize()
        {
            StateMachine = new CharacterStateMachine();
            Movement = new CharacterMovement(Rigidbody, PersonData.SpeedMove, PersonData.SpeedRun);
            // ...
        }
        
        public void Jump()
        {
            Movement.Jump();
            Animator.CrossFade("Jump", 0.1f);
        }
        
        public void Walk() => print("Walk");
    }
}