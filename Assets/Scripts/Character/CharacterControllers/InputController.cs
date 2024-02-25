using Character.Classes;
using Character.StateMachine.CharacterStates;
using Input;
using UnityEngine;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        private readonly InputHandler _inputHandler;

        public InputController(Person person) : base(person)
        {
            _inputHandler = new InputHandler();
        }

        protected override void CheckConditions()
        {
            if (CheckFall()) return;
            if (CheckJump()) return;
            if (CheckRoll()) return;
            if (CheckWalking()) return;

            StateMachine.ExitState();
        }

        private bool CheckWalking()
        {
            if (!Movement.IsGrounded() || _inputHandler.GetHorizontalAxis() == 0) return false;
            
            SetTempDirection();
            Movement.Direction = GetDirection();
            StateMachine.ChangeState(_inputHandler.GetShiftBtn()
                ? (CharacterState) StateMachine.RunState
                : StateMachine.WalkState);
            return true;
        }

        private bool CheckJump()
        {
            if (!Movement.IsGrounded() || _inputHandler.GetVerticalAxis() <= 0) return false;

            StateMachine.ChangeState(StateMachine.JumpState);
            return true;
        }

        private bool CheckFall()
        {
            if (Movement.IsGrounded()) return false;

            StateMachine.ChangeState(StateMachine.FallState);
            return true;
        }

        private bool CheckRoll()
        {
            if (!Movement.IsGrounded() || !_inputHandler.GetSpaceBtn()) return false;

            StateMachine.ChangeState(StateMachine.RollState);
            return true;
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());

        private void SetTempDirection()
        {
            if (_inputHandler.GetHorizontalAxis() != 0)
                Movement.TempDirection = new Vector2(_inputHandler.GetHorizontalAxis(), 0);
        }
    }
}