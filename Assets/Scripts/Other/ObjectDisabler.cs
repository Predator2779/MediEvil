using UnityEngine;

namespace Other
{
    public class ObjectDisabler : MonoBehaviour
    {
        [SerializeField] private GameObject _object;
        private void OnCollisionEnter2D(Collision2D other) => _object.SetActive(false);
    }
}