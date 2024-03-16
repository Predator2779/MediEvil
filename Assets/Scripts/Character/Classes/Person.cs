using Character.Movement;
using Character.StateMachine;
using Character.ValueStorages;
using Character.ValueStorages.Bars;
using Global;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Person : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayer { get; set; }
        [field: SerializeField] public CharacterData Data { get; set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; set; }
        [field: SerializeField] public Animator Animator { get; set; }
        [field: SerializeField] private ValueBar HealthBar { get; set; }
        [field: SerializeField] private ValueBar StaminaBar { get; set; }
        [field: SerializeField] private ValueBar ManaBar { get; set; }
        public CharacterMovement Movement { get; private set; }
        private Rigidbody2D Rigidbody { set; get; }
        public CharacterStateMachine StateMachine { get; set; }
        
        // Прокинуть Zenject-ом
        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }
        public Mana Mana { get; private set; }
        /*public float _radius;
        public float _myOffset;*/
        public void Execute() => StateMachine.ExecuteState();
        public void FixedExecute() => StateMachine.FixedExecute();

        private CapsuleCollider2D _capsule;
        private ContactPoint2D _contact;
        
        private void OnCollisionStay2D(Collision2D other)
        {
            _contact = other.contacts[0];
            _capsule = GetComponent<CapsuleCollider2D>();

            if (_contact.point.y > 
                _capsule.transform.position.y + 
                GlobalConstants.CollisionOffset + 
                _capsule.offset.y - _capsule.size.y / 2) return;    
            
            Movement.ContactPoint = other.contacts[0].point;
            Movement.ContactNormal = other.contacts[0].normal;
        }

        /*private void OnDrawGizmos()
        {
            if (capsule == null) return;;
            
            var pos = new Vector2(capsule.transform.position.x, capsule.transform.position.y + capsule.offset.y - capsule.size.y / 2);
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pos, _radius);   
            
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(contact.point, _radius); 
            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(Movement.ContactPoint, _radius);
        }*/

        public virtual void Initialize()
        {
            SetComponents();
            SetValues();
        }

        private void SetComponents()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Movement = new CharacterMovement(Rigidbody, Data);
            StateMachine = new CharacterStateMachine(this);
        }

        private void SetValues()
        {
            Health = new Health(this, Data.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Mana = new Mana(this, Data.MaxMana, ManaBar);
            
            // Set current values
            Health.SetValue(Health.MaxValue);
            Stamina.SetValue(Stamina.MaxValue);
            Mana.SetValue(Mana.MaxValue);
        }

        public void Idle() => StateMachine.ChangeState(StateMachine.IdleState);
        public void Walk() => StateMachine.ChangeState(StateMachine.WalkState);
        public void Run() => StateMachine.ChangeState(StateMachine.RunState);
        public void Jump() => StateMachine.ChangeState(StateMachine.JumpState);
        public void Roll() => StateMachine.ChangeState(StateMachine.RollState);
        public void Fall() => StateMachine.ChangeState(StateMachine.FallState);
        public void Slide() => StateMachine.ChangeState(StateMachine.SlideState);
        public void FallDown() => StateMachine.ChangeState(StateMachine.FallDownState);
        public void Die() => StateMachine.ForcedChangeState(StateMachine.DeathState);
    }
}