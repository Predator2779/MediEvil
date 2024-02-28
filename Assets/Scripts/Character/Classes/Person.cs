using Character.Movement;
using Character.StateMachine;
using Character.ValueStorages;
using Character.ValueStorages.Bars;
using UnityEngine;

namespace Character.Classes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Person : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayer { get; set; }
        [field: SerializeField] public CharacterData Data { get; set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; set; }
        [field: SerializeField] public Animator Animator { get; set; }
        [field: SerializeField] public ValueBar HealthBar { get; set; }
        [field: SerializeField] public ValueBar StaminaBar { get; set; }
        [field: SerializeField] public ValueBar ManaBar { get; set; }
        public CharacterMovement Movement { get; private set; }
        public Health Health { get; private set; }
        public Stamina Stamina { get; private set; }
        public Mana Mana { get; private set; }
        private Rigidbody2D Rigidbody { set; get; }
        public CharacterStateMachine StateMachine { get; set; }

        public void Execute() => StateMachine.ExecuteState();
        public void FixedExecute() => StateMachine.FixedExecute();
        private void OnCollisionStay2D(Collision2D other) => Movement.ContactPoint = other.contacts[0].point;

        public virtual void Initialize()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Movement = new CharacterMovement(Rigidbody, Data);
            StateMachine = new CharacterStateMachine(this);

            Health = new Health(this, Data.MaxHealth, HealthBar);
            Health.SetValue(Health.MaxValue);
            Stamina = new Stamina(this, Data.MaxStamina, StaminaBar);
            Stamina.SetValue(Stamina.MaxValue);
            Mana = new Mana(this, Data.MaxMana, ManaBar);
            Mana.SetValue(Mana.MaxValue);
        }

        public void Idle() => StateMachine.ChangeState(StateMachine.IdleState);
        public void Walk() => StateMachine.ChangeState(StateMachine.WalkState);
        public void Run() => StateMachine.ChangeState(StateMachine.RunState);
        public void Jump() => StateMachine.ChangeState(StateMachine.JumpState);
        public void Roll() => StateMachine.ChangeState(StateMachine.RollState);
        public void Fall() => StateMachine.ChangeState(StateMachine.FallState);
        public void Die() => StateMachine.ChangeState(StateMachine.DeathState);
    }
}