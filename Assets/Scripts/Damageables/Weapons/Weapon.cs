using System;
using Character.ComponentContainer;
using Character.ValueStorages;
using Environments.Items;
using UnityEngine;

namespace Damageables.Weapons
{
    public class Weapon : Item
    {
        [field: SerializeField] private float WeaponDamage { get; set; }
        [field: SerializeField] private float AttackRadius { get; set; }

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rbody;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rbody = GetComponent<Rigidbody2D>();
        }

        public override void PickUp()=> Take(false);
        public override void Put() => Take(true);

        private void Take(bool value)
        {
            _spriteRenderer.enabled = value;
            _rbody.simulated = value;
        }

        public void DoDamage(float personDamage, LayerMask layerMask)
        {
            var colliders = Physics2D.OverlapCircleAll(GetDetectedPoint(), AttackRadius, layerMask);

            if (colliders == null) return;

            foreach (var collider in colliders)
            {
                if (!collider.TryGetComponent(out PersonContainer person)) continue;
                
                var baseDamage = WeaponDamage * personDamage;
                // дополнительный урон от половины базового урона
                var additional = baseDamage * GetDistanceModificator(person.transform) / 2;
                
                DoDamage(person.Health, baseDamage + additional);
            }
        }

        public void DoDamage(Health health, float concreteDamage) => health.TakeDamage(concreteDamage);
        private Vector2 GetDetectedPoint() => new Vector2(transform.position.x + AttackRadius * Mathf.Sign(transform.rotation.y), transform.position.y);
        
        private float GetDistanceModificator(Transform target)
        {
            var totalDistance = AttackRadius * 2;
            var modificator = 1 - GetDistance(target) / totalDistance;
            return modificator;
        }

        private float GetDistance(Transform target) => 
            Mathf.Clamp(Vector2.Distance(transform.position, target.position), 0, AttackRadius);
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(GetDetectedPoint(), AttackRadius);    
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.01f);
        }
    }
}