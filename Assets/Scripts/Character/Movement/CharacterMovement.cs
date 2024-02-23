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
            int jumpForce)
        {
            _rbody = rbody;
            SpeedMove = speedMove;
            SpeedRun = speedRun;
            JumpForce = jumpForce;
        }

        public void Walk() => _rbody.velocity = Direction * SpeedMove;
        public void Roll() => _rbody.AddForce(Direction * RollDistance, ForceMode2D.Impulse); // test
        public void Run() => _rbody.velocity = Direction * SpeedRun;
        public void Jump() => _rbody.AddForce(GetJumpVector() * JumpForce, ForceMode2D.Impulse);
        public bool IsGrounded() => _rbody.velocity.y == 0;
        private Vector2 GetJumpVector() => new Vector2(_rbody.velocity.normalized.x, 1);
    }
}