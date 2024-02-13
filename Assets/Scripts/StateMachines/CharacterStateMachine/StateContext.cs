namespace Character.StateMachines.CharacterStateMachine
{
    public abstract class StateContext<T>
    {
        public T CurrentState { get; }
        public abstract void SetState(T state);
        public abstract void EnterState();
        public abstract void ExecuteState();
        public abstract void ExitState();
    }
}