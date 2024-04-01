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
            Person.Health.CanDamage = false;
            Person.Stamina.Decrease(Person.Config.StaminaUsage * GlobalConstants.RollStaminaUsageCoef);
        }

        public override void Execute()
        {
            SafetyCompleting();
            Person.Movement.SetSideByVelocity();
        }

        public override void Exit()
        {
            base.Exit();
            Person.Health.CanDamage = true;
        }

        public override void FixedExecute() {}
    }
}