using Character.Classes;
using Character.ValueStorages;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Weapon.Traps
{
    public class Trap : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _damageMin, _damageMax;

        private void OnTriggerEnter2D(Collider2D other) => EnableTrap(other);

        public void DoDamage(Health health, float damage) => health.TakeDamage(damage);
        private float GetDamageValue() => Random.Range(_damageMin, _damageMax);

        protected virtual void EnableTrap(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out Person person)) DoDamage(person.Health, GetDamageValue());
        }
    }
}