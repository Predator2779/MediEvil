using Global;
using UnityEngine;

namespace Character.Movement
{
    public class CharacterMovement
    {
        public Vector2 Direction { get; set; }
        public Vector2 TempDirection { get; set; } = new Vector2(1, 0);
        public Vector2 ContactPoint { get; set; }
        private Rigidbody2D _rbody;
        private CharacterData _data;

        public CharacterMovement(Rigidbody2D rbody, CharacterData data)
        {
            _rbody = rbody;
            _data = data;
        }

        public void Walk() => _rbody.velocity = GetHorizontalDirection() * _data.SpeedMove * GlobalConstants.CoefPersonSpeed;
        public void Run() => _rbody.velocity = GetHorizontalDirection() * _data.SpeedRun * GlobalConstants.CoefPersonSpeed;
        public void Roll() => _rbody.velocity = GetRollVector() * _data.RollDistance;
        public bool IsGrounded() => Mathf.Abs(_rbody.position.y - ContactPoint.y) <= GlobalConstants.MaxGroundOffset;
        public bool IsFall() => _rbody.velocity.y < -GlobalConstants.MaxGroundOffset;
        private Vector2 GetJumpVector() => new Vector2(Direction.x, 1);
        private Vector2 GetRollVector() => new Vector2(TempDirection.normalized.x, 0.4f);
        private Vector2 GetHorizontalDirection() => new Vector2(Direction.x, 0);

        public void Jump()
        {
            _rbody.velocity = Vector2.zero;
            _rbody.AddForce(GetJumpVector() * _data.JumpForce * _rbody.mass, ForceMode2D.Impulse);
        }
    }
}