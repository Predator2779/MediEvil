using Character.Classes;
using Character.ComponentContainer;

namespace Character.CharacterControllers
{
    public abstract class Controller
    {
        protected readonly Person _person;

        protected Controller(PersonContainer container)
        {
            _person = new Person(container);
        }

        public virtual void Initialize() => _person.Initialize();
        public virtual void Execute() => _person.StateMachine.Execute();
        public virtual void FixedExecute() => _person.StateMachine.FixedExecute();
    }
}