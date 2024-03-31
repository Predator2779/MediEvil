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
            Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.JumpStaminaUsageCoef);
        }

        public override void Execute()
        {
            Person.Movement.SetSideByVelocity();
            SafetyCompleting();
        }

        public override void FixedExecute() => Person.Movement.FallMove();
    }
}