using UnityEngine;

namespace Other
{
    public class Following : MonoBehaviour
    {
        [SerializeField] private Transform _followObject;
        [SerializeField] private float _speed;

        private Vector3 _offset;

        private void Start() => _offset = transform.position - _followObject.transform.position;
        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, 
                _followObject.position + _offset, _speed
                * Time.deltaTime
                );
        }
    }
}