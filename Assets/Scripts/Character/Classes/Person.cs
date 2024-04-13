using Character.ComponentContainer;
using Character.StateMachine;
using Character.StateMachine.StateSets;

namespace Character.Classes
{
    public class Person
    {
        public PersonContainer Container { get; set; }
        public PersonStateMachine StateMachine { get; set; }
        private PersonStateSet _personStateSet;

        public Person(PersonContainer container)
        {
            Container = container;
        }

        public virtual void Initialize()
        {
            Subscribe();

            _personStateSet = new PersonStateSet(this);
            StateMachine = new PersonStateMachine(_personStateSet.DefaultState);
        }

        private void Subscribe()
        {
            Container
                .Health
                .Falldown
                += FallDown;
            Container.Health.Die += Die;
        }

        public void Describe()
        {
            Container.Health.Falldown -= FallDown;
            Container.Health.Die -= Die;
        }

        public void Idle() => StateMachine.ChangeState(_personStateSet.IdleState);
        public void Walk() => StateMachine.ChangeState(_personStateSet.WalkState);
        public void Run() => StateMachine.ChangeState(_personStateSet.RunState);
        public void Jump() => StateMachine.ChangeState(_personStateSet.JumpState);
        public void Roll() => StateMachine.ChangeState(_personStateSet.RollState);
        public void Fall() => StateMachine.ChangeState(_personStateSet.FallState);
        public void Slide() => StateMachine.ChangeState(_personStateSet.SlideState);
        public void FallDown() => StateMachine.ChangeState(_personStateSet.FallDownState);
        public void Die() => StateMachine.ForcedChangeState(_personStateSet.DeathState);
    }
}