using Global;
using UnityEngine;

namespace Character.Movement
{
    public class CharacterMovement
    {
        public Vector2 Direction { get; set; }
        public bool IsGrounded { get; set; } = true;
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
        public void Jump() => _rbody.AddForce(GetJumpVector() * JumpForce * _rbody.mass, ForceMode2D.Impulse);
        public void Roll() => _rbody.velocity = Direction.normalized * RollDistance;
        private Vector2 GetJumpVector() => new Vector2(Direction.x, 1);
    }
}