﻿using UnityEngine;

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
            _capsule = _person.Movement.Capsule;
        }
        
        protected override void CheckConditions()
        {
            SetTempDirection();
            
            if (CanIdle()) return;
            if (CanFollow()) return;
            
            _person.Idle();
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
            
            _person.Idle();
            return true;
        }
        
        protected bool CanFollow()
        {
            _target = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _followRadius, _layerMask);

            if (_target == null) return false;

            if (GetTargetDistance() > _dashRadius || Vector2.Angle(_person.Movement.ContactNormal, Vector2.up) >= 85)
            {
                _person.Roll();
                return true;
            }  
            
            if (GetTargetDistance() > _runRadius)
            {
                _person.Run();
                return true;
            }
            
            _person.Walk();
            return true;
        }
        
        protected virtual void SetTempDirection()
        {
            if (_target == null) return;

            _person.Movement.Direction = GetTargetVector();
            _person.Movement.TempDirection = GetTargetVector();
        }

        protected Vector2 GetTargetVector() => _target.transform.position - _person.transform.position;
        protected float GetTargetDistance() => Vector2.Distance(_person.transform.position, _target.transform.position);
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