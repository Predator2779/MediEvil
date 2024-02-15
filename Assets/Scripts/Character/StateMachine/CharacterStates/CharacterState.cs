using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected CharacterState(Animator animator)
        {
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}