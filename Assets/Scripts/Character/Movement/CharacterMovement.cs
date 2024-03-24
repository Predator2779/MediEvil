﻿using Character.Classes;
using Global;
using UnityEngine;

namespace Character.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Person))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class CharacterMovement : MonoBehaviour
    {
        public Vector2 Direction { get; set; }
        public Vector2 TempDirection { get; set; } = new Vector2(1, 0);
        public Vector2 ContactPoint { get; set; }
        public Vector2 ContactNormal { get; set; }

        private Rigidbody2D _rbody;
        private CharacterData _data;

        public float _radius;
        public float _line;
        public float _requireAngle;
        private CapsuleCollider2D _capsule;
        private ContactPoint2D _contact;
        private ContactPoint2D[] _contacts;
        private float _angle;

        private void Start()
        {
            _capsule = GetComponent<CapsuleCollider2D>();
            _rbody = GetComponent<Rigidbody2D>();
            _data = GetComponent<Person>().Data;
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            _contacts = other.contacts;
            _contact = GetNearestPoint(_contacts);

            if (Vector2.Distance(_contact.point, ContactPoint) <= 0.02f && !CorrectAngle(_contact.normal)) return;
            
            // if (пред точка близко к новой) return;

            ContactPoint = _contact.point;
            ContactNormal = _contact.normal;
        }

        private ContactPoint2D GetNearestPoint(ContactPoint2D[] contacts) // пока что.
        {
            var length = contacts.Length;
            var position = _capsule.transform.position;
            var contact = contacts[0];
            var value = Vector2.Distance(position, contacts[0].point);

            for (int i = 0; i < length; i++)
            {
                var newValue = Vector2.Distance(position, contacts[i].point);

                if (newValue >= value) continue;
                
                contact = contacts[i];
                value = newValue;
            }

            return contact;
        }
        
        private float RequireOffset() =>
            _capsule.transform.position.y +
            _capsule.offset.y - _capsule.size.y / 2 +
            GlobalConstants.CollisionOffset;
        
        private bool CorrectAngle(Vector2 normal) => Vector2.Angle(normal, Vector2.up) <= _requireAngle;
        
        private void OnDrawGizmos()
        {
            if (_capsule == null) return;;

            var pos = new Vector2(_capsule.transform.position.x, RequireOffset());

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pos, _radius);

            if (_contacts != null)
            {
                foreach (var contact in _contacts)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(contact.point, _radius);
                }
            }
            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_contact.point, _radius);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(ContactPoint, _radius);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(ContactPoint, ContactNormal * _line);
        }
        
        public void Walk() => _rbody.velocity = GetHorizontalDirection(_data.SpeedMove * GlobalConstants.CoefPersonSpeed);
        public void Run() => _rbody.velocity = GetHorizontalDirection(_data.SpeedRun * GlobalConstants.CoefPersonSpeed);
        public void FallMove() => _rbody.velocity = GetHorizontalDirection(_data.SpeedMove * _data.FallSpeed * GlobalConstants.HorizontalFallMoveSpeed);
        public void Jump() => _rbody.AddForce(GetJumpVector() * _data.JumpForce * _rbody.mass, ForceMode2D.Impulse);
        public void Roll() => _rbody.velocity = GetRollVector() * _data.RollForce;
        public void Slide() => _rbody.AddForce(GetSlideVector() * _data.SlideSpeed, ForceMode2D.Impulse);
        public void SetBodyType(RigidbodyType2D type) => _rbody.bodyType = type;
        public bool IsGrounded() => ContactPoint.y <= _rbody.position.y + GlobalConstants.CollisionOffset &&
                                    _rbody.position.y - ContactPoint.y <= GlobalConstants.MaxGroundOffset;
        // public bool IsGrounded() => Mathf.Abs(_rbody.position.y - ContactPoint.y) <= GlobalConstants.MaxGroundOffset;
        public bool IsFall() => _rbody.velocity.y < -GlobalConstants.FallSpeed;
        public bool CanSlide() => Mathf.Abs(GetHorizontalVelocity()) >= _data.SlideLimitVelocity;
        private Vector2 GetHorizontalDirection(float speed) => new Vector2(Direction.x * speed, _rbody.velocity.y);
        private Vector2 GetRollVector() => new Vector2(TempDirection.normalized.x, GlobalConstants.RollVerticalForce);
        private Vector2 GetSlideVector() => new Vector2(_rbody.velocity.x, _rbody.velocity.y);
        private Vector2 GetJumpVector() => new Vector2(Direction.normalized.x * GlobalConstants.HorizontalJumpCoef, 1);
        public float GetHorizontalVelocity() => _rbody.velocity.x;
    }
}