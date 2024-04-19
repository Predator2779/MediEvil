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

        public void DoDamage(Health health, float concreteDamage) => health.TakeDamage(concreteDamage);

        public void DoDamage(float personDamage, LayerMask layerMask)
        {
            var collider = Physics2D.OverlapCircle(transform.position, AttackRadius, layerMask);

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

        public override void PickUp()=> Take(false);
        public override void Put() => Take(true);

        private void Take(bool value)
        {
            _spriteRenderer.enabled = value;
            _rbody.simulated = value;
        }
    }
}