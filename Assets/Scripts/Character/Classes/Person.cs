using Character.CharacterControllers;
using Character.Movement;
using Character.StateMachine;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class Person : MonoBehaviour
    {
        [field: SerializeField] private bool IsPlayer { get; set; }
        [field: SerializeField] private CharacterData CharacterData { get; set; }
        protected Controller Controller { get; set; } // // //
        protected Rigidbody2D Rigidbody { set; get; }
        public CharacterStateMachine StateMachine { get; protected set; }
        public CharacterMovement Movement { get; protected set; }
        public SpriteRenderer SpriteRenderer { get; protected set; }
        public Animator Animator { get; protected set; }

        private void Start() => Initialize();
        private void Update() => Controller.Execute();
        private void FixedUpdate() => Controller.FixedExecute();
        private void OnCollisionEnter2D(Collision2D other) => Movement.IsGrounded = true;
        private void OnCollisionExit2D(Collision2D other) => Movement.IsGrounded = false;

        protected virtual void Initialize()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            Movement = new CharacterMovement(
                Rigidbody,
                CharacterData.SpeedMove,
                CharacterData.SpeedRun,
                CharacterData.JumpForce,
                CharacterData.RollDistance);

            StateMachine = new CharacterStateMachine(this);
            Controller = new InputController(this); ///
        }

        public void Die()
        {
            print("You Died");
        }
    }
}