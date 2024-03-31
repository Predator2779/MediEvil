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
            ChangingIndicators();
            Person.Movement.Run();
        }

        protected override void ChangingIndicators() => Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.RunStaminaUsageCoef);
    }
}