using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class JumpState : CharacterState
    {
        public JumpState(Person person) : base(person)
        {
            Animation = "jump";
        }

        public override void Enter()
        {
            if (!Person.Movement.IsGrounded() || !Person.Stamina.CanUse()) return;
            
            base.Enter();
            Person.Movement.Jump();
            Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.JumpStaminaUsageCoef);
        }

        public override void Execute()
        {
            if (Person.Movement.IsFall()) Person.Fall();
        }

        public override void FixedExecute()
        {
        }
    }
}