using Character.Movement;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Person : MonoBehaviour
    {
        [SerializeField] private AnimStateChanger _animStateChanger;
        private CharacterMovement _movement;

        [field: SerializeField] public bool IsRun { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedMove { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedRun { get; set; }

        private void Start() => _movement = GetComponent<CharacterMovement>();

        public void Move(Vector2 direction)
        {
            _movement.SetDirection(direction);
            _movement.SetSpeed(GetSpeed());
            
            if (direction.x == 0)
            {
                _animStateChanger.AnimationStopWalk();
                return;
            }

            _animStateChanger.AnimateWalk(direction, GetAnimSpeed());
        }

        private float GetSpeed() => IsRun ? SpeedRun : SpeedMove;
        private float GetAnimSpeed() => IsRun ? 1.5f : 1;
    }
}