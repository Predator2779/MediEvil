using UnityEngine;

namespace Other
{
    public class ObjectDisabler : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var o in _objects) o.SetActive(false);
        }
    }
}