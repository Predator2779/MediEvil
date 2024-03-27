using Damageables.Weapon;
using UnityEngine;

namespace Character.Classes
{
    public class Warrior : Person
    {
        [field: SerializeField] public Weapon Weapon { get; set; }
    }
}