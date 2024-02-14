using Character.Classes;
using Character.Movement;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Person : MonoBehaviour
    {
        [SerializeField] private AnimStateChanger _animStateChanger;
        private CharacterMovement _movement;

<<<<<<< Updated upstream:Assets/Scripts/Character/Person.cs
=======
        // to movement
        [field: SerializeField] public bool IsRun { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedMove { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedRun { get; set; }

>>>>>>> Stashed changes:Assets/Scripts/Character/Classes/Person.cs
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
<<<<<<< Updated upstream:Assets/Scripts/Character/Person.cs
        
        // private float GetAnimSpeed() => IsRun ? 1.5f : 1;
=======

        // to movement
        private float GetSpeed() => IsRun ? SpeedRun : SpeedMove;
        private float GetAnimSpeed() => IsRun ? 1.5f : 1;
>>>>>>> Stashed changes:Assets/Scripts/Character/Classes/Person.cs
    }
}