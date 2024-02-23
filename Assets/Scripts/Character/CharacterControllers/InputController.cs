﻿using Character.Classes;
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
            if (CheckJump()) return;
            if (CheckRoll()) return;
            if (CheckWalking()) return;
            
            StateMachine.ExitState();
        }

        private bool CheckWalking()
        {
            if (_inputHandler.GetHorizontalAxis() == 0) return false;

            Movement.Direction = GetDirection();
            StateMachine.ChangeState(_inputHandler.GetShiftBtn() ? (CharacterState) StateMachine.RunState : StateMachine.WalkState);
            return true;
        }

        private bool CheckJump()
        {
            if (_inputHandler.GetVerticalAxis() <= 0) return false;
            
            StateMachine.ChangeState(StateMachine.JumpState);
            return true;
        }

        private bool CheckRoll()
        {
            if (!_inputHandler.GetSpaceBtn()) return false;
            
            StateMachine.ChangeState(StateMachine.RollState);
            return true;
        }
        
        private Vector2 GetDirection() => new Vector2(
            _inputHandler.GetHorizontalAxis(),
            _inputHandler.GetVerticalAxis());
    }
}