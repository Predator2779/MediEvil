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
        [field: SerializeField] private ValueBar HealthBar { get; set; }
        [field: SerializeField] private ValueBar StaminaBar { get; set; }
        [field: SerializeField] private ValueBar ManaBar { get; set; }
        
        public CharacterMovement Movement { get; private set; }
        public PersonStateMachine StateMachine { get; set; }
        
        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }
        public Mana Mana { get; private set; }

        private void Awake() => Initialize();

        public virtual void Initialize()
        {
            SetComponents();
            SetValues();
        }

        private void SetComponents()
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