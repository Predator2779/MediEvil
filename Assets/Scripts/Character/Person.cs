using Character.Movement;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Person : MonoBehaviour
    {
        [SerializeField] private AnimStateChanger _animStateChanger;
        private CharacterMovement _movement;

        private void Start() => _movement = GetComponent<CharacterMovement>();

        public CharacterMovement GetMovement() => _movement;
        public SpriteRenderer GetSpriteRenderer() => GetComponent<SpriteRenderer>();
        public Animator GetAnimator() => GetComponent<Animator>();
        public void Move(Vector2 direction)
        {
            _movement.SetDirection(direction);
            
            // _movement.SetSpeed(GetSpeed());
            //
            // if (direction.x == 0)
            // {
            //     _animStateChanger.AnimationStopWalk();
            //     return;
            // }
            //
            // _animStateChanger.AnimateWalk(direction, GetAnimSpeed());
        }
        
        // private float GetAnimSpeed() => IsRun ? 1.5f : 1;
    }
}