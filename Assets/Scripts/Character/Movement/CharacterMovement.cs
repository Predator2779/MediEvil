using UnityEngine;

namespace Character.Movement
{
    public class CharacterMovement
    {
        private Rigidbody2D _rbody;
        private bool IsWalk { get; set; }
        private bool IsRun { get; set; }
        private Vector2 HorizontalDirection { get; set; }
        private int SpeedMove { get; set; }
        private int SpeedRun { get; set; }


        public CharacterMovement(Rigidbody2D rbody, int speedMove, int speedRun)
        {
            _rbody = rbody;
            SpeedMove = speedMove;
            SpeedRun = speedRun;
        }

        public void Jump() => Debug.Log("Jumped!");
    }
}