using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public JumpState(Person person) : base(person)
        {
            Animation = "jump";
        }

        public override void Enter()
        {
            if (!Person.Movement.IsGrounded()) return;
            
            base.Enter();
            Person.Movement.Jump();
        }

        public override void Execute()
        {

            
            /*if (Person.Movement.IsGrounded()) Person.Idle();
            else Person.Fall();*/
        }
    }
}