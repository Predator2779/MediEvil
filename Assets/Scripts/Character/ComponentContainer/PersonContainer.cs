using System;
using Character.CharacterControllers;
using Character.Movement;
using Character.StateMachine;
using Character.StateMachine.StateSets;
using Character.ValueStorages;
using Character.ValueStorages.Bars;
using UnityEngine;

namespace Character.ComponentContainer
{
    public class PersonContainer : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayer { get; set; }
        [field: SerializeField] public CharacterConfig Config { get; set; }
        [field: SerializeField] public Animator Animator { get; set; }
        
        [field: SerializeField] public ValueBar HealthBar { get; set; }
        [field: SerializeField] public ValueBar StaminaBar { get; set; }
        [field: SerializeField] public ValueBar ManaBar { get; set; }
        
        public CharacterMovement Movement { get; protected set; }

        public Health Health { get; protected set; }
        public Stamina Stamina { get; protected set; }
        public Mana Mana { get; protected set; }

        private void Awake()
        {
            Movement = GetComponent<CharacterMovement>();

            Health = new Health(this, Config.CurrentHealth, Config.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Config.CurrentStamina, Config.MaxStamina, StaminaBar);
            Mana = new Mana(this, Config.CurrentMana, Config.MaxMana, ManaBar);
        }
    }
}