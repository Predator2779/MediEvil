using Global;
using Input;
using UnityEngine;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        private InputHandler _inputHandler;

        protected override void CheckConditions()
        {
            SetTempDirection();

            if (CheckSlide()) return;
            if (CheckFall()) return;
            if (CheckJump()) return;
            if (CheckRoll()) return;
            if (CheckWalking()) return;

            Person.Idle();
        }

        protected override void Initialize()
        {
            base.Initialize();
            _inputHandler = new InputHandler();
        }

        private bool CheckFall()
        {
            if (Person.Movement.IsGrounded() || !Person.Movement.IsFall()) return false;

            Person.Fall();
            return true;
        }

        private bool CheckJump()
        {
            if (!Person.Stamina.CanUse() || Person.Movement.IsFall() || _inputHandler.GetVerticalAxis() <= 0) return false;

            Person.Jump();
            return true;
        }

        private bool CheckSlide()
        {
            // bool для разового использования
            if (!Person.Movement.IsGrounded() || !Person.Movement.CanSlide() || _inputHandler.GetVerticalAxis() >= 0) return false;

            Person.Slide();
            return true;
        }

        private bool CheckRoll()
        {
            if (!Person.Stamina.CanUse() || !Person.Movement.IsGrounded() || !_inputHandler.GetSpaceBtn()) return false;

            Person.Roll();
            return true;
        }

        private bool CheckWalking()
        {
            if (!Person.Movement.IsGrounded() || _inputHandler.GetHorizontalAxis() == 0) return false;

            if (_inputHandler.GetShiftBtn() && Person.Stamina.CanUse()) Person.Run();
            else Person.Walk();

            return true;
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());

        private void SetTempDirection()
        {
            Person.Movement.Direction = GetDirection();
            
            if (_inputHandler.GetHorizontalAxis() != 0)
                Person.Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }
}