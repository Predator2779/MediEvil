using Character.Classes;
using Character.StateMachine;
using Character.StateMachine.StateSets;
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
            _warrior.SetStateMachine(new PersonStateSet(_warrior));
        }
        
        protected override void CheckConditions()
        {
            SetTempDirection();

            if (CheckFall()) return;
            if (CheckJump()) return;
            if (CheckSlide()) return;
            if (CheckRoll()) return;
            if (CheckAttack()) return;
            if (CheckWalking()) return;

            _person.Idle();
        }

        private bool CheckFall()
        {
            if (_person.Movement.IsGrounded() || !_person.Movement.IsFall()) return false;

            _person.Fall();
            return true;
        }

        private bool CheckJump()
        {
            if (!_person.Stamina.CanUse() || _person.Movement.IsFall() || !_person.Movement.IsGrounded() || _inputHandler.GetVerticalAxis() <= 0) return false;

            _person.Jump();
            return true;
        }

        private bool CheckSlide()
        {
            // bool для разового использования
            // атака в прыжке (для варриора)
            if (!_person.Movement.IsGrounded() || !_person.Movement.CanSlide() || _inputHandler.GetVerticalAxis() >= 0) return false;

            _person.Slide();
            return true;
        }

        private bool CheckRoll()
        {
            if (!_person.Stamina.CanUse() || _person.Movement.IsFall() || !_person.Movement.IsGrounded() || !_inputHandler.GetSpaceBtn()) return false;

            _person.Roll();
            return true;
        }

        private bool CheckAttack() ///////////////
        {
            if (!_inputHandler.GetLMB()) return false;

            // (Warrior)Person.Weapon
            _warrior.Attack();
            return true;
        }
        
        private bool CheckWalking()
        {
            if (!_person.Movement.IsGrounded() || _inputHandler.GetHorizontalAxis() == 0) return false;

            if (_inputHandler.GetShiftBtn() && _person.Stamina.CanUse()) _person.Run();
            else _person.Walk();

            return true;
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());

        private void SetTempDirection()
        {
            _person.Movement.Direction = GetDirection();
            
            if (Mathf.Abs(_inputHandler.GetHorizontalAxis()) > 0)
                _person.Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }}