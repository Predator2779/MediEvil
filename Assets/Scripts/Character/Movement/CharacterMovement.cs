﻿using Global;
using UnityEngine;

namespace Character.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        [field: SerializeField] public bool IsWalk { get; set; }
        [field: SerializeField] public bool IsRun { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedMove { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedRun { get; set; }
        public Vector2 HorizontalDirection { get; set; }
        
        private Rigidbody2D _rbody;

        private void Start() => _rbody = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream

        private void FixedUpdate()
        {
            if (IsWalk) Walk();
        }
        
        public void SetDirection(Vector2 direction) => HorizontalDirection = new Vector2(direction.x, 0);
        private void Walk() => _rbody.velocity = 
            new Vector2(HorizontalDirection.x * GetSpeed() * GlobalConstants.CoefPersonSpeed, _rbody.velocity.y);
        private float GetSpeed() => IsRun ? SpeedRun : SpeedMove;
=======
        private void FixedUpdate() => Walk();
        public void SetDirection(Vector2 direction) => _horizontalDirection = new Vector2(direction.x, 0);
        public void SetSpeed(float speed) => _speed = speed * GlobalConstants.CoefPersonSpeed;
        public void Jump() => print("Jumped!");
        private void Walk() => _rbody.velocity = new Vector2(_horizontalDirection.x * _speed, _rbody.velocity.y);
>>>>>>> Stashed changes
    }
}