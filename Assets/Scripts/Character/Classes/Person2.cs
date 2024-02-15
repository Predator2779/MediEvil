using Character.CharacterControllers;
using Character.Movement;
using Character.StateMachine;
using Character.StateMachine.CharacterStates;
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
        public IdleState IdleState { get; set; }
        public WalkState WalkState { get; set; }

        
        [field: SerializeField] private bool IsPlayer { get; }
        [field: SerializeField] private PersonData PersonData { get; }
        [field: SerializeField] public Controller Controller { get; protected set; } // прокинуть Zenject-ом
        [field: SerializeField] public CharacterStateMachine StateMachine { get; protected set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; protected set; }
        [field: SerializeField] public CharacterMovement Movement { get; protected set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; protected set; }
        [field: SerializeField] public Animator Animator { get; protected set; }
        // [field: SerializeField] public IHealth Health { get; }

        private void Start() => Initialize();
        private void Update() => Controller.Execute();

        protected virtual void Initialize()
        {
            StateMachine = new CharacterStateMachine();
            Rigidbody = GetComponent<Rigidbody2D>();
            Movement = new CharacterMovement(Rigidbody, PersonData.SpeedMove, PersonData.SpeedRun);
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            
            IdleState = new IdleState(Animator);
            WalkState = new WalkState(this, Animator);
        }

        /*public void Idle()
        {
            StateMachine.ChangeState();
        }
        public void Walk() => print("Walk");
        public void Run() => print("Run");
        public void Roll() => print("Roll");
        public void Slide() => print("Slide");
        public void Fall() => print("Fall");
        public void Climb() => print("Climb");

        public void Jump()
        {
            Movement.Jump();
            Animator.CrossFade("Jump", 0.1f);
        }
        */
    }
}