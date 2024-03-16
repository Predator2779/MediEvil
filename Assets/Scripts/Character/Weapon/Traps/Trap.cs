﻿using Character.Classes;
using Character.ValueStorages;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character.Weapon.Traps
{
    public class Trap : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _damageMin, _damageMax;

        private void OnTriggerEnter2D(Collider2D other) => EnableTrap(other);

        public void DoDamage(Health health, float damage) => health.TakeDamage(damage);
        protected float GetDamageValue() => Random.Range(_damageMin, _damageMax);

        protected virtual void EnableTrap(Collider2D collider)
        {
            if (!collider.gameObject.TryGetComponent(out Person person)) return;
            DoDamage(person.Health, GetDamageValue());
            person.FallDown();
        }
    }
}