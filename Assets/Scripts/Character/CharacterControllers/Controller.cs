using Character.Classes;
using Character.StateMachine.CharacterStates;

namespace Character.CharacterControllers
{
    public abstract class Controller
    {
        public Person2 Person { get; }

        public Controller(Person2 person)
        {
            Person = person;
        }

        public virtual void Execute()
        {
            Person.StateMachine.ExecuteState();
        }

        public virtual void AnalyseCondition()
        {
            if (Condition1) Person.StateMachine.ChangeState(Person.IdleState);
            
            /// ...
        }

        public bool Condition1 { get; set; }
    }
}