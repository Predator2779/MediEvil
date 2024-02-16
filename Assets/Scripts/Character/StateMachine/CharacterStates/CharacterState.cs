using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public abstract class CharacterState
    {
        protected Person Person { get; }

        protected CharacterState(Person person)
        {
            Person = person;
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}