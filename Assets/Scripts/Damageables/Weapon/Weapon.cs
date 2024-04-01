using Character.Classes;
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

            if (!collider || !collider.TryGetComponent(out Person person)) return;
            
            var damage = WeaponDamage * personDamage / GetDistanceDamageModificator(person.transform);
            DoDamage(person.Health, damage);
        }

        private float GetDistanceDamageModificator(Transform target) => 
            AttackRadius / Vector2.Distance(transform.position, target.position);
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackRadius);
        }
    }
}