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
        public void Execute() => StateMachine.ExecuteState();
        public void FixedExecute() => StateMachine.FixedExecute();
        
        public float _radius;
        public float _line;
        public float _angle1;
        private CapsuleCollider2D _capsule;
        private ContactPoint2D _contact;
        private float _angle;
        
        private void OnCollisionStay2D(Collision2D other)
        {
            _contact = other.contacts[0];

            if (_contact.point.y > RequireOffset()) return;

            // if (пред точка близко к новой) return;

            print(_angle);
            
            Movement.ContactPoint = other.contacts[0].point;
            Movement.ContactNormal = other.contacts[0].normal;
        }

        /*private ContactPoint2D GetNearestPoint(ContactPoint2D[] contacts) // пока что.
        {
            var length = contacts.Length;
            var position = _capsule.transform.position;
            var contact = contacts[0];
            var value = contacts[0].point.y;

            for (int i = 1; i < length; i++)
            {
                var newValue = Vector2.Distance(position, contacts[i].point);
                if (newValue >= value) continue;
                contact = contacts[i];
                value = newValue;
            }

            return contact;
        }*/
        
        private float RequireOffset() =>
            _capsule.transform.position.y +
            _capsule.offset.y - _capsule.size.y / 2 +
            GlobalConstants.CollisionOffset;
        
        private bool CorrectAngle()
        {
            var angle = Vector2.Angle(_contact.normal, Vector2.up);
            _angle = angle;
            return angle >= -_angle1 && angle <= _angle1;
        }
        
        private void OnDrawGizmos()
        {
            if (_capsule == null) return;;

            var pos = new Vector2(_capsule.transform.position.x, _capsule.transform.position.y + GlobalConstants.CollisionOffset);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pos, _radius);   
            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_contact.point, _radius); 
            
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(Movement.ContactPoint, _radius);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(Movement.ContactPoint, Movement.ContactNormal * _line);
        }

        public virtual void Initialize()
        {
            SetComponents();
            SetValues();
        }

        private void SetComponents()
        {
            _capsule = GetComponent<CapsuleCollider2D>();
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