using Character.Classes;
using UnityEngine;

namespace Character.Weapon.Traps
{
    public class OneShotTrap : Trap
    {
        [SerializeField] private bool _disableCollider;

        private Collider2D _collider;

        private void Start() => _collider = GetComponent<Collider2D>();

        protected override void EnableTrap(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Person person)) DoDamage(person.Health, GetDamageValue());
            if (_disableCollider && _collider != null) Destroy(_collider);
            Destroy(this);
        }
    }
}