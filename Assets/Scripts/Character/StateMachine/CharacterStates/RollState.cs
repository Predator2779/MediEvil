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
            if (!Person.Movement.IsGrounded() || !Person.Stamina.CanUse()) return;

            base.Enter();
            Person.Movement.Roll();
            Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.RollStaminaUsageCoef);
        }

        public override void Execute() => SafetyCompleting();

        public override void FixedExecute()
        {
        }
    }
}