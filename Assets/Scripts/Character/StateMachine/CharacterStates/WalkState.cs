using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class WalkState : CharacterState
    {
        public WalkState(Person person) : base(person)
        {
            Animation = "walk";
        }

        public override void FixedExecute()
        {
            base.FixedExecute();
            if (Person.Movement.IsGrounded()) Person.Movement.Walk();
        }
    }
}