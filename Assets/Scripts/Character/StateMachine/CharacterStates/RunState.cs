using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class RunState : TiredState
    {
        public RunState(Person person) : base(person)
        {
            Animation = "run";
        }
        
        public override void Execute() => Person.Movement.SetSideByVelocity();
        
        public override void FixedExecute()
        {
            base.FixedExecute();
            // if (Person.Movement.IsGrounded()) Person.Movement.Walk();
            ChangingIndicators();
            Person.Movement.Run();
        }

        protected override void ChangingIndicators() => Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.RunStaminaUsageCoef);
    }
}