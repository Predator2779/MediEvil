using Global;
using UnityEngine;

namespace Character.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody2D _rbody;
        private Vector2 _horizontalDirection;
        private float _speed;

        private void Start() => _rbody = GetComponent<Rigidbody2D>();
        private void FixedUpdate() => Walk();
        public void SetDirection(Vector2 direction) => _horizontalDirection = new Vector2(direction.x, 0);
        public void SetSpeed(float speed) => _speed = speed * GlobalConstants.CoefPersonSpeed;
        
        private void Walk() => _rbody.velocity = new Vector2(_horizontalDirection.x * _speed, _rbody.velocity.y);
    }
}