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
            base.Enter();
            Person.Movement.Jump();
        }
        
        public override void Execute() => SafetyCompleting();

        public override void FixedExecute()
        {
            Person.Movement.Walk();
            Person.Stamina.Decrease(Person.Data.StaminaUsage * GlobalConstants.JumpStaminaUsageCoef);
        }
    }
}