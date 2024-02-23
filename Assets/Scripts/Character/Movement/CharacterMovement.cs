using Global;
using UnityEngine;

namespace Character.Movement
{
    public class CharacterMovement
    {
        public Vector2 Direction { get; set; }
        private Rigidbody2D _rbody;
        private int SpeedMove { get; }
        private int SpeedRun { get; }
        private int JumpForce { get; }
        private int RollDistance { get; }

        public CharacterMovement(
            Rigidbody2D rbody,
            int speedMove,
            int speedRun,
            int jumpForce,
            int rollDistance)
        {
            _rbody = rbody;
            SpeedMove = speedMove;
            SpeedRun = speedRun;
            JumpForce = jumpForce;
            RollDistance = rollDistance;
        }

        public void Walk() => _rbody.velocity = Direction * SpeedMove * GlobalConstants.CoefPersonSpeed;
        public void Run() => _rbody.velocity = Direction * SpeedRun * GlobalConstants.CoefPersonSpeed;
        public void Roll() => _rbody.velocity = Direction.normalized * RollDistance;
        public void Jump() => _rbody.AddForce(GetJumpVector() * JumpForce, ForceMode2D.Impulse);
        public bool IsGrounded() => _rbody.velocity.y > GlobalConstants.VerticalVelocityForGround;
        private Vector2 GetJumpVector() => new Vector2(_rbody.velocity.normalized.x, 1);
    }
}