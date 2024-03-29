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
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; set; }
        [field: SerializeField] public Animator Animator { get; set; }
        [field: SerializeField] protected ValueBar HealthBar { get; set; }
        [field: SerializeField] protected ValueBar StaminaBar { get; set; }
        [field: SerializeField] protected ValueBar ManaBar { get; set; }
        
        public CharacterMovement Movement { get; protected set; }
        public PersonStateMachine StateMachine { get; set; }
        
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
            SetStateMachine(new PersonStateMachine(this));
            Movement = GetComponent<CharacterMovement>();
            
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

        public void SetStateMachine(PersonStateMachine stateMachine) => StateMachine = stateMachine;
        
        public void Idle() => StateMachine.ChangeState(StateMachine.IdleState);
        public void Walk() => StateMachine.ChangeState(StateMachine.WalkState);
        public void Run() => StateMachine.ChangeState(StateMachine.RunState);
        public void Jump() => StateMachine.ChangeState(StateMachine.JumpState);
        public void Roll() => StateMachine.ChangeState(StateMachine.RollState);
        public void Fall() => StateMachine.ChangeState(StateMachine.FallState);
        public void Slide() => StateMachine.ChangeState(StateMachine.SlideState);
        public void FallDown() => StateMachine.ChangeState(StateMachine.FallDownState);
        public void Die() => StateMachine.ForcedChangeState(StateMachine.DeathState);
    }
}