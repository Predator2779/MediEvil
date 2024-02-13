using System;

namespace Character.StateMachines.CharacterStateMachine.States
{
    public abstract class State<T>
    {
        protected StateContext<T> _context;

        public virtual void Enter(StateContext<T> context)
        {
            _context = context;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public abstract void Exit();
    }
}