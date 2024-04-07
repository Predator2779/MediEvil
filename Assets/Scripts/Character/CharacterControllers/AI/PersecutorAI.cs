﻿using Character.Classes;
using Global;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character.CharacterControllers.AI
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class PersecutorAI : Controller
    {
        [SerializeField] protected float _viewingRadius;
        [SerializeField] protected float _runDistance;
        [SerializeField] protected float _walkDistance;
        [SerializeField] protected float _stayDistance;
        [SerializeField] protected LayerMask _layerMask;

        protected Collider2D _target;
        private CapsuleCollider2D _capsule;

        // private void OnDrawGizmos()
        // {
        //     if (_capsule == null) return;
        //
        //     Gizmos.color = Color.green;
        //     Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _viewingRadius);
        //     
        //     Gizmos.color = Color.yellow;
        //     Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _runDistance);
        //
        //     Gizmos.color = Color.blue;
        //     Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _walkDistance);
        //
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawWireSphere(GetCapsuleCenterPos(), _stayDistance);
        // }
        
        public override void Initialize()
        {
            base.Initialize();
            _capsule = _person.Container.Movement.Capsule;
        }

        public override void Execute()
        {
            base.Execute();

            SetTempDirection();
            
            if (!HasTarget() || CanStay())
            {
                Idle();
                return;
            }

            if (CanWalkFollow())
            {
                WalkFollow();
                return;
            }  
            
            if (CanRunFollow())
            {
                RunFollow();
            }
        }

        protected bool HasTarget()
        {
            _target = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _viewingRadius, _layerMask);
            return _target;
        }
        
        // protected bool CanDash() => Physics2D.OverlapCircle(GetCapsuleCenterPos(), _dashRadius, _layerMask);
        protected bool CanStay() => GetTargetDistance() <= _stayDistance;
        protected bool CanWalkFollow() => GetTargetDistance() <= _walkDistance;
        protected bool CanRunFollow() => GetTargetDistance() <= _runDistance;

        // protected void Follow()
        // {
        //     if (GetTargetDistance() > _dashRadius || Vector2.Angle(_person.Movement.ContactNormal, Vector2.up) >= 85)
        //     {
        //         Roll();
        //     }
        //
        //     if (GetTargetDistance() > _runDistance)
        //     {
        //         RunFollow();
        //         return;
        //     }
        //
        //
        // }

        protected void Roll() => _person.Roll();

        protected void RunFollow()
        {
            if (Random.Range(0, GlobalConstants.RollChanceAI) == 0) Roll();
            else _person.Run();
        }
        
        protected void WalkFollow() => _person.Walk();
        protected void Idle() => _person.Idle();

        protected virtual void SetTempDirection()
        {
            if (_target == null) return;

            _person.Container.Movement.Direction = GetTargetVector();
            _person.Container.Movement.TempDirection = GetTargetVector();
        }

        protected float GetTargetDistance() => Vector2.Distance(transform.position, _target.transform.position);
        protected Vector2 GetTargetVector() => _target.transform.position - _person.Container.transform.position;

        protected Vector2 GetCapsuleCenterPos() =>
            new Vector2(_capsule.transform.position.x,
                _capsule.transform.position.y + _capsule.size.y / 2);
        
    }
}