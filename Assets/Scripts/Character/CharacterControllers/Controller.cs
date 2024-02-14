using Character.Classes;

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
    }
}