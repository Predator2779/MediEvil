using Character.StateMachine;
using Character.StateMachine.StateSets;

namespace Character.Processors
{
    public class PersonProcessor
    {
        private readonly PersonStateMachine _stateMachine;
        private readonly PersonStateSet _stateSet;

        public PersonProcessor(PersonStateMachine stateMachine, PersonStateSet stateSet)
        {
            _stateMachine = stateMachine;
            _stateSet = stateSet;
        }
        
        public void Idle() => _stateMachine.ChangeState(_stateSet.IdleState);
        public void Walk() => _stateMachine.ChangeState(_stateSet.WalkState);
        public void Run() => _stateMachine.ChangeState(_stateSet.RunState);
        public void Jump() => _stateMachine.ChangeState(_stateSet.JumpState);
        public void Roll() => _stateMachine.ChangeState(_stateSet.RollState);
        public void Fall() => _stateMachine.ChangeState(_stateSet.FallState);
        public void Slide() => _stateMachine.ChangeState(_stateSet.SlideState);
        public void FallDown() => _stateMachine.ChangeState(_stateSet.FallDownState);
        public void Die() => _stateMachine.ForcedChangeState(_stateSet.DeathState);
    }
}