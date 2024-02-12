using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class AnimStateChanger : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        public void AnimateWalk(Vector2 direction, float animSpeed = 1)
        {
            _spriteRenderer.flipX = !(direction.x >= 0);
            _animator.SetBool("Walk", true);
            _animator.speed = animSpeed;
        }

        public void AnimationStopWalk() => _animator.SetBool("Walk", false);
    }
}