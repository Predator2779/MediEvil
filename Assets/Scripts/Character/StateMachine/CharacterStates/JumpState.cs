using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public JumpState(Person person) : base(person)
        {
        }

        public override void Enter()
        {
            Animation = "jump";
            base.Enter();
            Person.Movement.Jump();
        }
    }
}