using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : TiredState
    {
        public RollState(Person person) : base(person)
        {
            Animation = "roll";
        }

        public override void Enter()
        {
            base.Enter();
            Person.Movement.Roll();
            Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.RollStaminaUsageCoef);
        }

        public override void Execute()
        {
            SafetyCompleting();
            Person.Movement.SetSideByVelocity();
        }
        
        public override void FixedExecute() {}
    }
}