using Character.CharacterControllers;
using Character.Movement;
using Character.StateMachine;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Person : MonoBehaviour
    {
        [field: SerializeField] private bool IsPlayer { get; set; }
        [field: SerializeField] private CharacterData CharacterData { get; set; }
        [field: SerializeField] private SpriteRenderer SpriteRenderer { get; set; }
        [field: SerializeField] private Animator Animator { get; set; }
        protected Controller Controller { get; set; } // // //
        protected Rigidbody2D Rigidbody { set; get; }
        public CharacterStateMachine StateMachine { get; protected set; }
        public CharacterMovement Movement { get; protected set; }

        private void Start() => Initialize();
        private void Update() => Controller.Execute();
        private void FixedUpdate() => Controller.FixedExecute();
        private void OnCollisionStay2D(Collision2D other) => Movement.ContactPoint = other.contacts[0].point;

        protected virtual void Initialize()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Movement = new CharacterMovement(Rigidbody, CharacterData);

            StateMachine = new CharacterStateMachine(this, SpriteRenderer, Animator);
            Controller = new InputController(this); ///
        }

        public void Die()
        {
            print("You Died");
        }
    }
}