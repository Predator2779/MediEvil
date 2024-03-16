using Character.Classes;
using Character.ValueStorages;
using UnityEngine;

namespace Character.Weapon.Traps
{
    public class Trap : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _damageMin, _damageMax;

        private void OnCollisionEnter2D(Collision2D collision) => EnableTrap(collision);
        public void DoDamage(Health health, float damage) => health.TakeDamage(damage);
        protected float GetDamageValue() => Random.Range(_damageMin, _damageMax);
        protected virtual void EnableTrap(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out Person person)) return;
            DoDamage(person.Health, GetDamageValue());
        }
    }
}