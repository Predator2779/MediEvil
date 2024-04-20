using Character.Classes;
using Character.StateMachine.CharacterStates;
using Character.StateMachine.CharacterStates.ThrowerStates;

namespace Character.StateMachine.StateSets
{
    public class ThrowerStateSet : PersonStateSet
    {
        public ThrowState ThrowState { get; }
        public TwistedThrowState TwistedThrowState { get; }

        public ThrowerStateSet(Thrower thrower) : base(thrower)
        {
            ThrowState = new ThrowState(thrower);
            TwistedThrowState = new TwistedThrowState(thrower);
        }
    }
}