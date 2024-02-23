using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class AttackState : CharacterState
    {
        public AttackState(Person person, string animName) : base(person, animName)
        {
        }
    }
}