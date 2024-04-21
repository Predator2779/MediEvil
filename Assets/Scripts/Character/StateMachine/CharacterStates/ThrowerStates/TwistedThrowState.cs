using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates.ThrowerStates
{
    public class TwistedThrowState : ThrowState
    {
        public TwistedThrowState(Thrower thrower) : base(thrower)
        {
        }

        protected override void Throw()
        {
            base.Throw();
            _weapon.GetRBody()
                .AddTorque(
                    Thrower
                        .Container
                        .Config
                        .ThrowTwistedForce, ForceMode2D.Impulse);
        }
    }
}