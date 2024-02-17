using Character.StateMachine;
using Character.StateMachine.CharacterStates;
using Input;
using UnityEngine;

namespace Character.CharacterControllers
{
    public class InputController : Controller
    {
        private readonly InputHandler _inputHandler;

        public InputController(InputHandler inputHandler, CharacterStateMachine stateMachine) : base(stateMachine)
        {
            _inputHandler = inputHandler;
        }

        public override void Execute()
        {
            base.Execute();
            CheckInput();
        }

        private void CheckInput()
        {
            CheckWalking();
        }

        private void CheckWalking()
        {
        }

        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());
    }
}