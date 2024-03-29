using Character.Movement;
using Character.StateMachine;
using Character.StateMachine.CharacterStates.WarriorStates;
using Character.ValueStorages;
using Damageables.Weapon;
using UnityEngine;

namespace Character.Classes
{
    public class Warrior : Person
    {
        [field: SerializeField] public Weapon Weapon { get; set; }
        public WarriorStateMachine WarriorStateMachine { get; set; }
        
        protected override void SetComponents()
        {
            SetStateMachine(new WarriorStateMachine(this));
            Movement = GetComponent<CharacterMovement>();
            
            Health = new Health(this, Data.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Mana = new Mana(this, Data.MaxMana, ManaBar);
        }

        public void Attack() => StateMachine.ChangeState(new AttackState(this));
    }
}