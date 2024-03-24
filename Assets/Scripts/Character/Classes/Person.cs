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
        public CharacterStateMachine StateMachine { get; set; }
        
        // Прокинуть Zenject-ом
        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }
        public Mana Mana { get; private set; }
        public void Execute() => StateMachine.ExecuteState();
        public void FixedExecute() => StateMachine.FixedExecute();

        public virtual void Initialize()
        {
            SetComponents();
            SetValues();
        }

        private void SetComponents()
        {
            Movement = GetComponent<CharacterMovement>();
            StateMachine = new CharacterStateMachine(this);
        }

        private void SetValues()
        {
            Health = new Health(this, Data.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Mana = new Mana(this, Data.MaxMana, ManaBar);
            
            // Set current values
            Health.SetValue(Health.MaxValue);
            Stamina.SetValue(Stamina.MaxValue);
            Mana.SetValue(Mana.MaxValue);
        }

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