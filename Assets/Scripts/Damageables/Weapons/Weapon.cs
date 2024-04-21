using Character.Classes;
using Character.ComponentContainer;
using Character.ValueStorages;
using Environments.Items;
using Global;
using UnityEngine;

namespace Damageables.Weapons
{
    public class Weapon : Item
    {
        [field: SerializeField] public WeaponData Data { get; set; }

        private Thrower _thrower;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rbody;
        private Collider2D _collider;
        private bool _isPulled;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        private void FixedUpdate() => CheckPull();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PersonContainer container))
                DoDamage(container.Health, GetDamage());
        }

        private float GetDamage() =>
            _thrower
                .Container
                .Config
                .Damage
            * _thrower
                .Container
                .Config
                .DamageThrowDamage
            * _rbody.velocity.magnitude;

        public void Pull(Thrower thrower)
        {
            transform.parent = null;
            _rbody.simulated = true;
            _thrower = thrower;
            _rbody.AddTorque(GlobalConstants.ThrowTorque, ForceMode2D.Force);
            _isPulled = true;
        }

        public override void PickUp() => Take(true);
        public override void Put() => Take(false);
        public Rigidbody2D GetRBody() => _rbody;

        public void Throw(Thrower thrower, Vector2 force)
        {
            _thrower = thrower;
            _rbody.AddForce(force, ForceMode2D.Impulse);
        }
        
        private void Take(bool value)
        {
            _spriteRenderer.enabled = !value;
            _rbody.simulated = !value;
            _collider.isTrigger = value;
        }

        private void CheckPull()
        {
            if (!_isPulled) return;

            _collider.isTrigger = true;
            Pulling();
        }

        private void Pulling()
        {
            _rbody.velocity = GetPullVector() * GlobalConstants.PullForce;
            CheckDistance();
        }

        private void CheckDistance()
        {
            if (IsNear()) Equip();
        }

        private void Equip()
        {
            _thrower.Container.WeaponHandler.EquipWeapon(this);
            transform.rotation = _thrower.Container.transform.rotation;
            _rbody.velocity = Vector2.zero;
            _isPulled = false;
        }

        private bool IsNear() => Vector2.Distance(transform.position, _thrower.Container.transform.position) <
                                 _thrower.Container.ItemHandler.GetDetectionRadius();

        public void DoDamage(float personDamage, LayerMask layerMask)
        {
            var colliders = Physics2D.OverlapCircleAll(GetDetectedPoint(), Data.AttackRadius, layerMask);

            if (colliders == null) return;

            foreach (var collider in colliders)
            {
                if (!collider.TryGetComponent(out PersonContainer person)) continue;

                var baseDamage = Data.Damage * personDamage;
                // дополнительный урон от половины базового урона
                var additional = baseDamage * GetDistanceModificator(person.transform) / 2;

                DoDamage(person.Health, baseDamage + additional);
            }
        }

        private void DoDamage(Health health, float concreteDamage) => health.TakeDamage(concreteDamage);
        private Vector2 GetPullVector() => _thrower.Container.transform.position - transform.position;

        private Vector2 GetDetectedPoint() =>
            new Vector2(transform.position.x + Data.AttackRadius * Mathf.Sign(transform.rotation.y), transform.position.y);

        private float GetDistanceModificator(Transform target)
        {
            var totalDistance = Data.AttackRadius * 2;
            var modificator = 1 - GetDistance(target) / totalDistance;
            return modificator;
        }

        private float GetDistance(Transform target) =>
            Mathf.Clamp(Vector2.Distance(transform.position, target.position), 0, Data.AttackRadius);

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(GetDetectedPoint(), Data.AttackRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.01f);
        }

#endif
    }
}