using Character.Classes;
using UnityEngine;

namespace Other
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Person person)) person.Die();
        }
    }
}