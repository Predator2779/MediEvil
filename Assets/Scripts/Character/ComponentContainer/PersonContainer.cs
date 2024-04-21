using Character.CharacterControllers;
using Character.Configs;
using Character.Interaction;
using Character.Movement;
using Character.StateMachine;
using Character.ValueStorages;
using Character.ValueStorages.Bars;
using Damageables.Weapons;
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

        public Controller Controller { get; set; }
        public CharacterMovement Movement { get; set; }
        public PersonStateMachine StateMachine { get; set; }
        public ItemHandler ItemHandler { get; set; }
        public WeaponHandler WeaponHandler { get; set; }

        public Health Health { get; protected set; }
        public Stamina Stamina { get; protected set; }
        public Mana Mana { get; protected set; }

        public void Initialize()
        {
            ItemHandler.OnWeaponPickedUp += WeaponHandler.EquipWeapon;
            SetComponents();
            Controller.Initialize();
        }

        private void Update() => Controller.Execute();
        private void FixedUpdate() => Controller.FixedExecute();

        private void SetComponents()
        {
            Health = new Health(this, Config.CurrentHealth, Config.MaxHealth, HealthBar);
            Stamina = new Stamina(this, Config.CurrentStamina, Config.MaxStamina, StaminaBar);
            Mana = new Mana(this, Config.CurrentMana, Config.MaxMana, ManaBar);
        }

        private void OnDestroy() => ItemHandler.OnWeaponPickedUp -= WeaponHandler.EquipWeapon;


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(GetMousePos(), 0.5f / 10);
        }

        private Vector2 GetMousePos()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition); /// divide responsibility

            var position = new Vector2();

            position.x = Mathf.Clamp(mousePos.x, -Camera.main.pixelWidth / 2, Camera.main.pixelWidth / 2);
            position.y = Mathf.Clamp(mousePos.y, -Camera.main.pixelHeight / 2, Camera.main.pixelHeight / 2);

            var sign = Mathf.Sign(transform.rotation.y);
            var min = transform.position.x;
            var max = transform.position.x + 100;

            if (sign >= 0)
                return new Vector2(Mathf.Clamp(position.x, min, max),
                    position.y);

            return new Vector2(Mathf.Clamp(position.x, -max, min),
                position.y);
        }
    }
}