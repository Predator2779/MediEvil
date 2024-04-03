using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : TiredState
    {
        public JumpState(Person person) : base(person)
        {
            Animation = "jump";
        }

        public override void Enter()
        {
            base.Enter();
            Person.Movement.Jump();
            Person.Stamina.Decrease(Person.Config.StaminaUsage * GlobalConstants.JumpStaminaUsageCoef);
        }

        public override void Execute()
        {
            Person.Movement.SetSideByVelocity();
            Person.Movement.FallMove();
            SafetyCompleting();
        }

        public override void FixedExecute() => Person.Movement.FallMove();
    }
}