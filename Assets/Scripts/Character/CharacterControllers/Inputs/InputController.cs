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
        private Thrower _thrower;
        private Mage _mage;
        private InputHandler _inputHandler;
        private bool _canCombo;

        // private IEnumerator ResetCombo()
        // {
        //     _canCombo = true;
        //     yield return new WaitForSeconds(_warrior.Config.ComboInterval);
        //     _canCombo = false;
        // }

        public InputController(PersonContainer container, Weapon weapon = null) : base(container)
        {
            _warrior = new Warrior(container, weapon);
            // _thrower = new Thrower(container);
            // _mage = new Mage(container);
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
            _warrior.StateMachine.Execute();/////////////////
            base.Execute();
            CheckConditions();
            SetTempDirection(GetDirection());
        }

        public override void FixedExecute()
        {
            base.FixedExecute();
            _warrior.StateMachine.FixedExecute();/////////////////
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());
        
        private bool IsWalk() => _inputHandler.GetHorizontalAxis() != 0 && _warrior.Container.Movement.IsGrounded();
        private bool IsRun() => _inputHandler.GetShiftBtn() && _warrior.Container.Stamina.CanUse;
        private bool IsFall() => !_warrior.Container.Movement.IsGrounded() && _warrior.Container.Movement.IsFall();
        
        private bool IsJump() => _inputHandler.GetVerticalAxis() > 0 &&
                                 _warrior.Container.Stamina.CanUse &&
                                 !_warrior.Container.Movement.IsFall() &&
                                 _warrior.Container.Movement.IsGrounded();

        // добавить атаку в прыжке (для варриора)
        private bool IsSlide() => _inputHandler.GetVerticalAxis() < 0 &&
                                  _warrior.Container.Movement.IsGrounded() &&
                                  _warrior.Container.Movement.CanSlide();

        private bool IsRoll() => _inputHandler.GetSpaceBtn() &&
                                 _warrior.Container.Stamina.CanUse &&
                                 !_warrior.Container.Movement.IsFall() &&
                                 _warrior.Container.Movement.IsGrounded();

        private bool IsAttack() => _inputHandler.GetLMB();
        private bool IsDefense() => _inputHandler.GetRMB();

        private void Attack()
        {
            if (_canCombo) _warrior.ComboAttack();
            else _warrior.Attack();

            // Observable.FromCoroutine(ResetCombo).Subscribe(_ =>
            // {
            //     
            // });

            // StopCoroutine(ResetCombo());
            // StartCoroutine(ResetCombo());
        }

        private void Defense() => _warrior.Defense();
        private void Fall() => _warrior.Fall();
        private void Jump() => _warrior.Jump();
        private void Slide() => _warrior.Slide();
        private void Roll() => _warrior.Roll();
        private void Run() => _warrior.Run();
        private void Walk() => _warrior.Walk();
        private void Idle() => _warrior.Idle();

        private void SetTempDirection(Vector2 input)
        {
            _warrior.Container.Movement.Direction = input;

            if (Mathf.Abs(input.x) > 0)
                _warrior.Container.Movement.TempDirection = new Vector2(input.x, 0);
            // _person.Container.Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }
}