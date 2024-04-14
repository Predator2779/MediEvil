using System.Threading.Tasks;
using Character.Classes;
using Character.ComponentContainer;
using Damageables.Weapon;
using Input;
using UnityEngine;

namespace Character.CharacterControllers.Inputs
{
    public sealed class InputController : Controller
    {
        private Warrior _warrior;
        private InputHandler _inputHandler;

        private bool _canCombo;
        private int _countComboClicks;

        public InputController(PersonContainer container, Weapon weapon = null) : base(container)
        {
            _warrior = new Warrior(container, weapon);
        }

        public override void Initialize()
        {
            base.Initialize();
            _warrior.Initialize();
            _inputHandler = new InputHandler();
        }

        private void CheckConditions()
        {
            if (IsFall())
            {
                Fall();
                return;
            }

            if (IsJump())
            {
                Jump();
                return;
            }

            if (IsSlide())
            {
                Slide();
                return;
            }

            if (IsRoll())
            {
                Roll();
                return;
            }

            if (IsDefense())
            {
                Defense();
                return;
            }

            if (_countComboClicks > 0 && CanEnterState())
            {
                _countComboClicks = 0;
                ComboAttack();
                return;
            }

            if (IsAttack())
            {
                Attack();
                return;
            }

            if (IsRun())
            {
                Run();
                return;
            }

            if (IsWalk())
            {
                Walk();
                return;
            }

            Idle();
        }

        public override void Execute()
        {
            base.Execute();
            TrackCombo();
            CheckConditions();
            SetTempDirection(GetDirection());
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());

        private bool IsWalk() => _inputHandler.GetHorizontalAxis() != 0 && _person.Container.Movement.IsGrounded();
        private bool IsRun() => _inputHandler.GetShiftBtn() && _person.Container.Stamina.CanUse;
        private bool IsFall() => !_person.Container.Movement.IsGrounded() && _person.Container.Movement.IsFall();

        private bool IsJump() => _inputHandler.GetVerticalAxis() > 0 &&
                                 _person.Container.Stamina.CanUse &&
                                 !_person.Container.Movement.IsFall() &&
                                 _person.Container.Movement.IsGrounded();

        // добавить атаку в прыжке (для варриора)
        private bool IsSlide() => _inputHandler.GetVerticalAxis() < 0 &&
                                  _person.Container.Movement.IsGrounded() &&
                                  _person.Container.Movement.CanSlide();

        private bool IsRoll() => _inputHandler.GetSpaceBtn() &&
                                 _person.Container.Stamina.CanUse &&
                                 !_person.Container.Movement.IsFall() &&
                                 _person.Container.Movement.IsGrounded();

        private bool IsAttack() => _inputHandler.GetLMB();
        private bool IsDefense() => _inputHandler.GetRMB();

        private void Attack()
        {
            SubscribeEndedAttack();
            _warrior.Attack();
        }

        private void ComboAttack()
        {
            SubscribeEndedAttack();
            _warrior.ComboAttack();
        }

        private void TrackCombo()
        {
            if (IsAttack() && _canCombo) _countComboClicks++;
        }

        private void SubscribeEndedAttack()
        {
            _canCombo = true;
            _warrior.OnEndedAttack += ResetCombo;
        }

        private void ResetCombo()
        {
            Debug.Log("Invoked");
            _warrior.OnEndedAttack -= ResetCombo;
            _canCombo = false;
            
            Task.Delay(_warrior.Container.Config.ComboInterval).ContinueWith(_ => { _countComboClicks = 0; });
        }

        private void Defense() => _warrior.Defense();
        private void Fall() => _person.Fall();
        private void Jump() => _person.Jump();
        private void Slide() => _person.Slide();
        private void Roll() => _person.Roll();
        private void Run() => _person.Run();
        private void Walk() => _person.Walk();
        private void Idle() => _person.Idle();
        private bool CanEnterState() => _person.Container.StateMachine.CurrentState.IsCompleted;
        private void SetTempDirection(Vector2 input)
        {
            _person.Container.Movement.Direction = input;

            if (Mathf.Abs(input.x) > 0)
                _person.Container.Movement.TempDirection = new Vector2(input.x, 0);
        }
    }
}