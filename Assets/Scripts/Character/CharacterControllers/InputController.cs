using Input;
using UnityEngine;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        private InputHandler _inputHandler;

        protected override void CheckConditions()
        {
            SetDirection();
            
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
            if (!Person.Movement.IsFall()) return false;

            Person.Fall();
            return true;
        }

        private bool CheckJump()
        {
            if (!Person.Movement.IsGrounded() || _inputHandler.GetVerticalAxis() <= 0) return false;

            Person.Jump();
            return true;
        }

        private bool CheckRoll()
        {
            if (!Person.Movement.IsGrounded() || !_inputHandler.GetSpaceBtn()) return false;

            Person.Roll();
            return true;
        }

        private bool CheckWalking()
        {
            if (!Person.Movement.IsGrounded() || _inputHandler.GetHorizontalAxis() == 0) return false;

            if (_inputHandler.GetShiftBtn()) Person.Run();
            else Person.Walk();

            return true;
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());

        private void SetDirection()
        {
            Person.Movement.Direction = GetDirection();
            
            if (_inputHandler.GetHorizontalAxis() != 0)
                Person.Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }
}