using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class PersecutorAI : Controller
    {
        [SerializeField] private Collider2D _target;
        [SerializeField] private float _followRadius;
        [SerializeField] private float _attackRadius;
        [SerializeField] private LayerMask _layerMask;

        private CapsuleCollider2D _capsule;

        protected override void Initialize()
        {
            base.Initialize();
            _capsule = GetComponent<CapsuleCollider2D>();
        }

        protected override void CheckConditions()
        {
            SetTempDirection();
            
            if (CanAttack()) return;
            if (CanFollow()) return;
            
            Person.Idle();
        }

        private bool CanAttack()
        {
            var collider = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);
            if (!collider) return false;
            
            Person.Idle();
            return true;
        } 
        
        private bool CanFollow()
        {
            _target = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _followRadius, _layerMask);

            if (_target == null || GetTargetDistance() > _followRadius) return false;
            
            Person.Walk();
            return true;
        }
        
        protected virtual void SetTempDirection()
        {
            if (_target == null) return;

            Person.Movement.Direction = GetTargetVector();
            Person.Movement.TempDirection = GetTargetVector();
        }

        private Vector2 GetTargetVector() => _target.transform.position - transform.position;
        private float GetTargetDistance() => Vector2.Distance(transform.position, _target.transform.position);
        private Vector2 GetCapsuleCenterPos() => (Vector2)_capsule.transform.position + _capsule.offset;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _followRadius);
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _attackRadius);
        }
    }
}