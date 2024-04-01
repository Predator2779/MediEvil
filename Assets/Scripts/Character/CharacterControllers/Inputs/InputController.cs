using System.Collections;
using Character.Classes;
using Global;
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

            if (IsAttack())
            {
                Attack();
                return;
            }

            if (IsRunning())
            {
                Run();
                return;
            }   
            
            if (IsWalking())
            {
                Walk();
                return;
            }

            Idle();
        }

        private bool IsFall() => !_person.Movement.IsGrounded() && _person.Movement.IsFall();

        private bool IsJump() => _person.Stamina.CanUse &&
                                    !_person.Movement.IsFall() &&
                                    _person.Movement.IsGrounded() &&
                                    _inputHandler.GetVerticalAxis() > 0;
        
        // добавить атаку в прыжке (для варриора)
        private bool IsSlide() => _person.Movement.IsGrounded() &&
                                     _person.Movement.CanSlide() &&
                                     _inputHandler.GetVerticalAxis() < 0;

        private bool IsRoll() => _person.Stamina.CanUse &&
                                    !_person.Movement.IsFall() &&
                                    _person.Movement.IsGrounded() &&
                                    _inputHandler.GetSpaceBtn();

        private bool IsAttack() => _inputHandler.GetLMB();
        private bool IsRunning() => IsWalking() && _inputHandler.GetShiftBtn() && _person.Stamina.CanUse;
        private bool IsWalking() => _person.Movement.IsGrounded() && _inputHandler.GetHorizontalAxis() != 0;

        private void Attack()
        {
            if (Random.Range(0, GlobalConstants.ComboChanceAI) == 0) _warrior.Attack(); 
            else _warrior.ComboAttack();
        }
        
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