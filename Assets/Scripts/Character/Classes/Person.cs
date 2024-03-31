using Character.Movement;
using Character.StateMachine;
using Character.StateMachine.StateSets;
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
        public PersonStateMachine StateMachine { get; set; }
        
        public Health Health { get; protected set; }
        public Stamina Stamina { get; protected set; }
        public Mana Mana { get; protected set; }
        
        private PersonStateSet _personStateSet;

        private void Awake() => Initialize();

        protected virtual void Initialize()
        {
            Movement = GetComponent<CharacterMovement>();

            Health = new Health(this, Data.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Mana = new Mana(this, Data.MaxMana, ManaBar);

            _personStateSet = new PersonStateSet(this);
            StateMachine = new PersonStateMachine(_personStateSet.DefaultState);
            
            SetValues();
        }
        
        private void SetValues() // убрать
        {
            Health.SetValue(Health.MaxValue);
            Stamina.SetValue(Stamina.MaxValue);
            Mana.SetValue(Mana.MaxValue);
        }
        
        public void Idle() => StateMachine.ChangeState(_personStateSet.IdleState);
        public void Walk() => StateMachine.ChangeState(_personStateSet.WalkState);
        public void Run() => StateMachine.ChangeState(_personStateSet.RunState);
        public void Jump() => StateMachine.ChangeState(_personStateSet.JumpState);
        public void Roll() => StateMachine.ChangeState(_personStateSet.RollState);
        public void Fall() => StateMachine.ChangeState(_personStateSet.FallState);
        public void Slide() => StateMachine.ChangeState(_personStateSet.SlideState);
        public void FallDown() => StateMachine.ChangeState(_personStateSet.FallDownState);
        public void Die() => StateMachine.ForcedChangeState(_personStateSet.DeathState);
    }
}