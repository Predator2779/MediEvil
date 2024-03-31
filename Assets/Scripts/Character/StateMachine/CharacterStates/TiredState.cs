using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class TiredState : CharacterState
    {
        public override bool CanEnter() => Person.Stamina.CanUse;

        public TiredState(Person person) : base(person)
        {
        }
    }
}