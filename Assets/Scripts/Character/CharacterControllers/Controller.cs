using Character.StateMachine;

namespace Character.CharacterControllers
{
    public abstract class Controller
    {
        public CharacterStateMachine StateMachine { get; }

        public Controller(CharacterStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Execute()
        {
            StateMachine.ExecuteState();
        }

        public virtual void AnalyseCondition()
        {
            if (Condition1) StateMachine.ChangeState(StateMachine.IdleState);
            
            /// ...
        }

        public bool Condition1 { get; set; }
    }
}