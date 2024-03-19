using System.Threading.Tasks;
using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates
{
    public class FallDownState : CharacterState
    {
        public FallDownState(Person person) : base(person)
        {
            Animation = "death";
        }

        public override void Enter()
        {
            IsCompleted = false;
            base.Enter();
        }

        public override void Execute()
        {
            if (!AnimationCompleted()) Task.Delay(GlobalConstants.FallDownDelay).ContinueWith(_ => IsCompleted = true);
        }
    }
}