using Character.Classes;
using Input;
using UnityEngine;

namespace Character.CharacterControllers.Inputs
{
    public sealed class InputController : Controller
    {
        private InputHandler _inputHandler;
        private Warrior _warrior;

        protected override void Initialize()
        {
            base.Initialize();
            _inputHandler = new InputHandler();
            _warrior = GetComponent<Warrior>();
        }

        protected override void Execute()
        {
            base.Execute();

            SetTempDirection();

            if (CheckFall())
            {
                Fall();
                return;
            }

            if (CheckJump())
            {
                Jump();
                return;
            }

            if (CheckSlide())
            {
                Slide();
                return;
            }

            if (CheckRoll())
            {
                Roll();
                return;
            }

            if (CheckAttack())
            {
                Attack();
                return;
            }

            if (CheckRunnig())
            {
                Run();
                return;
            }   
            
            if (CheckWalking())
            {
                Walk();
                return;
            }

            Idle();
        }

        private bool CheckFall() => !_person.Movement.IsGrounded() && _person.Movement.IsFall();

        private bool CheckJump() => _person.Stamina.CanUse &&
                                    !_person.Movement.IsFall() &&
                                    _person.Movement.IsGrounded() &&
                                    _inputHandler.GetVerticalAxis() > 0;
        
        // добавить атаку в прыжке (для варриора)
        private bool CheckSlide() => _person.Movement.IsGrounded() &&
                                     _person.Movement.CanSlide() &&
                                     _inputHandler.GetVerticalAxis() < 0;

        private bool CheckRoll() => _person.Stamina.CanUse &&
                                    !_person.Movement.IsFall() &&
                                    _person.Movement.IsGrounded() &&
                                    _inputHandler.GetSpaceBtn();

        private bool CheckAttack() => _inputHandler.GetLMB();
        private bool CheckRunnig() => CheckWalking() && _inputHandler.GetShiftBtn() && _person.Stamina.CanUse;
        private bool CheckWalking() => _person.Movement.IsGrounded() && _inputHandler.GetHorizontalAxis() != 0;

        private void Attack() => _warrior.Attack();
        private void Fall() => _person.Fall();
        private void Jump() => _person.Jump();
        private void Slide() => _person.Slide();
        private void Roll() => _person.Roll();
        private void Run() => _person.Run();
        private void Walk() => _person.Walk();
        private void Idle() => _person.Idle();
        
        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());

        private void SetTempDirection()
        {
            _person.Movement.Direction = GetDirection();

            if (Mathf.Abs(_inputHandler.GetHorizontalAxis()) > 0)
                _person.Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }
}