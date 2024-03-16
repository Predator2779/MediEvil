using Character.Classes;

namespace Character.StateMachine.CharacterStates
{
    public class FallDown : CharacterState
    {
        public FallDown(Person person) : base(person)
        {
            Animation = "death";
        }

        public override void Enter()
        {
            IsCompleted = false;
            base.Enter();
        }

        public override void Execute()
        {
            if (!AnimationCompleted()) return;
            IsCompleted = true;
            Person.Idle();
        }
    }
}