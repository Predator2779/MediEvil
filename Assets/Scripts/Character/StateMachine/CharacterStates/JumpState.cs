using Character.Classes;
using Character.ComponentContainer;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : TiredState
    {
        public JumpState(PersonContainer personContainer) : base(personContainer)
        {
            Animation = "jump";
        }

        public override void Enter()
        {
            base.Enter();
            PersonContainer.Movement.Jump();
            PersonContainer.Stamina.Decrease(PersonContainer.Config.StaminaUsage * GlobalConstants.JumpStaminaUsageCoef);
        }

        public override void Execute()
        {
            PersonContainer.Movement.SetSideByVelocity();
            PersonContainer.Movement.FallMove();
            SafetyCompleting();
        }

        public override void FixedExecute() => PersonContainer.Movement.FallMove();
    }
}