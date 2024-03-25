using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class RollState : WalkState
    {
        public RollState(Person person) : base(person)
        {
            Animation = "roll";
        }

        public override void Enter()
        {
            base.Enter();
            Person.Movement.Roll();
        }

        public override void Execute()
        {
            base.Execute();
            SafetyCompleting();
        }

        public override void FixedExecute()
        {
            Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.RollStaminaUsageCoef);
        }
    }
}