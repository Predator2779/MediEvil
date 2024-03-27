using UnityEngine;

namespace Character.CharacterControllers.AI
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class PersecutorAI : Controller
    {
        [SerializeField] protected Collider2D _target;
        [SerializeField] protected float _dashRadius;
        [SerializeField] protected float _runRadius;
        [SerializeField] protected float _followRadius;
        [SerializeField] protected float _attackRadius;
        [SerializeField] protected LayerMask _layerMask;

        private CapsuleCollider2D _capsule;
        
        protected override void Initialize()
        {
            base.Initialize();
            _capsule = Person.Movement.Capsule;
        }
        
        protected override void CheckConditions()
        {
            SetTempDirection();
            
            if (CanIdle()) return;
            if (CanFollow()) return;
            
            Person.Idle();
        }

        private bool CanDash()
        {
            var collider = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _dashRadius, _layerMask);
            if (!collider) return false;

            return true;
        }   
        
        private bool CanIdle()
        {
            var collider = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);
            if (!collider) return false;
            
            Person.Idle();
            return true;
        }
        
        protected bool CanFollow()
        {
            _target = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _followRadius, _layerMask);

            if (_target == null) return false;

            if (GetTargetDistance() > _dashRadius || Vector2.Angle(Person.Movement.ContactNormal, Vector2.up) >= 85)
            {
                Person.Roll();
                return true;
            }  
            
            if (GetTargetDistance() > _runRadius)
            {
                Person.Run();
                return true;
            }
            
            Person.Walk();
            return true;
        }
        
        protected virtual void SetTempDirection()
        {
            if (_target == null) return;

            Person.Movement.Direction = GetTargetVector();
            Person.Movement.TempDirection = GetTargetVector();
        }

        protected Vector2 GetTargetVector() => _target.transform.position - Person.transform.position;
        protected float GetTargetDistance() => Vector2.Distance(Person.transform.position, _target.transform.position);
        protected Vector2 GetCapsuleCenterPos() => 
            new Vector2(_capsule.transform.position.x, 
            _capsule.transform.position.y + _capsule.size.y / 2);
        
        private void OnDrawGizmos()
        {
            if (_capsule == null) return;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _runRadius);
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _dashRadius);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _followRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _attackRadius);
        }
    }
}