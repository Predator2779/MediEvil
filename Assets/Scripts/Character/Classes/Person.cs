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


        // to movement
        [field: SerializeField] public bool IsRun { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedMove { get; set; }
        [field: SerializeField, Range(0, 10)] private int SpeedRun { get; set; }

        private void Start() => _movement = GetComponent<CharacterMovement>();

        public CharacterMovement GetMovement() => _movement;
        public SpriteRenderer GetSpriteRenderer() => GetComponent<SpriteRenderer>();
        public Animator GetAnimator() => GetComponent<Animator>();

        // to movement
        private float GetSpeed() => IsRun ? SpeedRun : SpeedMove;
        private float GetAnimSpeed() => IsRun ? 1.5f : 1;
    }
}