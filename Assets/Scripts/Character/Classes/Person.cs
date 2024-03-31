using Character.Movement;
using Character.StateMachine;
using Character.ValueStorages;
using Character.ValueStorages.Bars;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Person : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayer { get; set; }
        [field: SerializeField] public CharacterData Data { get; set; }
        [field: SerializeField] public Animator Animator { get; set; }
        [field: SerializeField] protected ValueBar HealthBar { get; set; }
        [field: SerializeField] protected ValueBar StaminaBar { get; set; }
        [field: SerializeField] protected ValueBar ManaBar { get; set; }
        
        public CharacterMovement Movement { get; protected set; }
        protected PersonStateMachine StateMachine { get; set; }
        
        public Health Health { get; protected set; }
        public Stamina Stamina { get; protected set; }
        public Mana Mana { get; protected set; }

        private void Awake() => Initialize();

        protected virtual void Initialize()
        {
            SetComponents();
            SetValues();
        }

        protected virtual void SetComponents()
        {
            Movement = GetComponent<CharacterMovement>();
            StateMachine = new PersonStateMachine();
            
            Health = new Health(this, Data.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Mana = new Mana(this, Data.MaxMana, ManaBar);
        }

        private void SetValues() // убрать
        {
            Health.SetValue(Health.MaxValue);
            Stamina.SetValue(Stamina.MaxValue);
            Mana.SetValue(Mana.MaxValue);
        }
    }
}