namespace Character.StateMachine
{
    public abstract class CharacterState
    {
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}