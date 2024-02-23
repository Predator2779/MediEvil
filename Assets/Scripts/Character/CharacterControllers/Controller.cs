using Character.Classes;
using Character.Movement;
using Character.StateMachine;

namespace Character.CharacterControllers
{
    public abstract class Controller
    {
        public Person Person { get; }
        public CharacterStateMachine StateMachine { get; }
        public CharacterMovement Movement { get; }

        public Controller(Person person)
        {
            Person = person;
            StateMachine = person.StateMachine;
            Movement = person.Movement;
        }

        public virtual void Execute()
        {
            CheckConditions();
            StateMachine.ExecuteState();
        }

        public virtual void FixedExecute()
        {
            StateMachine.FixedExecute();
        }

        protected virtual void CheckConditions()
        {
            if (Condition1) StateMachine.ChangeState(StateMachine.IdleState);

            /// ...
        }

        private bool Condition1 { get; set; }
    }
}