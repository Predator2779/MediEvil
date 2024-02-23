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
        [field: SerializeField] protected Controller Controller { get; set; } // прокинуть Zenject-ом
        [field: SerializeField] protected Rigidbody2D Rigidbody { set; get; }
        [field: SerializeField] public CharacterStateMachine StateMachine { get; protected set; }
        [field: SerializeField] public CharacterMovement Movement { get; protected set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; protected set; }
        [field: SerializeField] public Animator Animator { get; protected set; }
        // [field: SerializeField] public IHealth Health { get; }

        private Vector2 HorizontalDirection { get; set; }

        private void Start() => Initialize();
        private void Update() => Controller.Execute();

        protected virtual void Initialize()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            Movement = new CharacterMovement(
                Rigidbody,
                CharacterData.SpeedMove,
                CharacterData.SpeedRun,
                CharacterData.JumpForce);

            StateMachine = new CharacterStateMachine(this);
            Controller = new InputController(this, StateMachine); ///
        }

        public void Die()
        {
            print("You Died");
        }
    }
}