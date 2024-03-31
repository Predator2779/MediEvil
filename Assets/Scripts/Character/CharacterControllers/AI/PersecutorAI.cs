using System;
using System.Collections;
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
            _capsule = _person.Movement.Capsule;
        }

        protected override void Execute()
        {
            base.Execute();

            SetTempDirection();

            if (CanIdle())
            {
                Idle();
                return;
            }

            if (CanFollow())
            {
                Follow();
                return;
            }

            Idle();
        }

        // protected bool CanDash() => Physics2D.OverlapCircle(GetCapsuleCenterPos(), _dashRadius, _layerMask);
        private bool CanIdle() => Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);

        protected bool CanFollow()
        {
            _target = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _followRadius, _layerMask);
            return _target;
        }

        protected void Follow()
        {
            if (GetTargetDistance() > _dashRadius || Vector2.Angle(_person.Movement.ContactNormal, Vector2.up) >= 85)
            {
                Roll();
            }

            if (GetTargetDistance() > _runRadius)
            {
                Run();
                return;
            }

            Walk();
        }

        private void Roll() => _person.Roll();
        private void Run() => _person.Run();
        private void Walk() => _person.Walk();
        protected void Idle() => _person.Idle();

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