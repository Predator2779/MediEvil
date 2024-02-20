using Character.Classes;
using Character.Movement;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : CharacterState
    {
        private CharacterMovement Movement { get; } 
        public RollState(Person person) : base(person)
        {
            Movement = person.Movement;
        }

        public override void Enter()
        {
            if (!Movement.IsGrounded()) return;
            
            Animation = "roll";
            base.Enter();
        }

        public override void Execute()
        {
            Movement.Roll();
            base.Execute();
        }
    }
}