using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class FallState : CharacterState
    {
        public FallState(Person person) : base(person)
        {
            Animation = "fall";
        }

        public override void Enter()
        {
            IsCompleted = false;
            base.Enter();
        }

        public override void Execute()
        {
            base.Execute();
            if (Person.Movement.IsGrounded()) IsCompleted = true;
        }

        public override void FixedExecute()
        {
            base.FixedExecute();
            // Person.Movement.FallMove();
        }
    }
}