using Character.Movement;
using Character.StateMachine;
using Character.StateMachine.CharacterStates.WarriorStates;
using Character.StateMachine.StateSets;
using Character.ValueStorages;
using Damageables.Weapon;
using UnityEngine;

namespace Character.Classes
{
    public class Warrior : Person
    {
        [field: SerializeField] public Weapon Weapon { get; set; }
        public WarriorStateSet PersonStateSet { get; set; }
        
        protected override void SetComponents()
        {
            // SetStateMachine(new PersonStateSet(this));
            Movement = GetComponent<CharacterMovement>();
            
            Health = new Health(this, Data.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Mana = new Mana(this, Data.MaxMana, ManaBar);
        }
    }
}