using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Person person) : base(person)
        {
            Animation = "attack";
        }
    }
}