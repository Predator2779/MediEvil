using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : WalkState
    {
        public RunState(Person person) : base(person)
        {
            Animation = "run";
        }

        public override void FixedExecute()
        {
            if (Person.Movement.IsGrounded()) Person.Movement.Run();
        }
    }
}