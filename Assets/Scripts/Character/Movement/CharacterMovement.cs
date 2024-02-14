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

        public void Jump() => print("Jumped!");
    }
}