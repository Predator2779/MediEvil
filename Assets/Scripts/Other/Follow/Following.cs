using UnityEngine;

namespace Other.Follow
{
    public class Following : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        [SerializeField] private bool _xFollowing, _yFollowing;
        
        private Vector3 _offset;

        private void Start() => _offset = transform.position - _target.transform.position;
        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, 
                GetTargetVector(), _speed
                * Time.deltaTime
                );
        }

        private Vector3 GetTargetVector()
        {
            var vector = _target.position + _offset;
            return new Vector3(
                _xFollowing ? vector.x : transform.position.x, 
                _yFollowing ? vector.y : transform.position.y, 
                transform.position.z);
        }
    }
}