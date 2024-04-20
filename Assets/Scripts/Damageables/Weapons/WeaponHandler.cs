using UnityEngine;

namespace Damageables.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        [field: SerializeField] public Weapon CurrentWeapon { get; set; }
        private Weapon DropedWeapon { get; set; }

        public void EquipWeapon(Weapon weapon)
        {
            DropWeapon();

            weapon.PickUp();
            weapon.transform.position = transform.position;
            weapon.transform.parent = transform;
            CurrentWeapon = weapon;
        }

        public void DropWeapon()
        {
            if (CurrentWeapon == null) return;

            DropedWeapon = CurrentWeapon;
            CurrentWeapon.Put();
            CurrentWeapon.transform.parent = null;
            CurrentWeapon = null;
        }
    }
}