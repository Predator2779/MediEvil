using Character.Classes;
using Character.ComponentContainer;
using Character.ValueStorages;
using UnityEngine;

namespace Damageables.Weapon
{
    public class Weapon : MonoBehaviour, IDamageable
    {
        [field: SerializeField] private float WeaponDamage { get; set; }
        [field: SerializeField] private float AttackRadius { get; set; }
        [field: SerializeField] private LayerMask LayerMask { get; set; }

        public void DoDamage(Health health, float concreteDamage) => health.TakeDamage(concreteDamage);

        public void DoDamage(float personDamage)
        {
            var collider = Physics2D.OverlapCircle(transform.position, AttackRadius, LayerMask);
            
            if (!collider || !collider.TryGetComponent(out PersonContainer person)) return;

            var baseDamage = WeaponDamage * personDamage;
            // дополнительный урон от половины базового урона
            var additional = baseDamage * GetDistanceModificator(person.transform) / 2;
            
            DoDamage(person.Health, baseDamage + additional);
        }

        private float GetDistanceModificator(Transform target)
        {
            var startPoint = new Vector2(transform.position.x - AttackRadius, transform.position.y);
            var totalDistance = AttackRadius * 2;
            var distance = Mathf.Clamp(Vector2.Distance(target.position, startPoint), 
                0, totalDistance);
            
            var modificator = 1 - distance / totalDistance;
            
            return modificator;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackRadius);
        }
    }
}