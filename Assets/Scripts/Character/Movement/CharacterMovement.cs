using Global;
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

        private void FixedUpdate()
        {
            if (IsWalk) Walk();
        }
        
        public void SetDirection(Vector2 direction) => HorizontalDirection = new Vector2(direction.x, 0);
        private void Walk() => _rbody.velocity = 
            new Vector2(HorizontalDirection.x * GetSpeed() * GlobalConstants.CoefPersonSpeed, _rbody.velocity.y);
        private float GetSpeed() => IsRun ? SpeedRun : SpeedMove;
    }
}