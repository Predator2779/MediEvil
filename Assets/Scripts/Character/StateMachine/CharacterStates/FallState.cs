using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class FallState : CharacterState
    {
        public FallState(Person person) : base(person)
        {
            Animation = "fall";
        }

        public override void FixedExecute()
        {
            base.FixedExecute();
            Person.Movement.FallMove();
        }
    }
}