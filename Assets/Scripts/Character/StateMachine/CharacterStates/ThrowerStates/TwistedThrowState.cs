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
            _weapon = Thrower.Container.WeaponHandler.CurrentWeapon;
            
            if (_weapon == null) return;
            
            Thrower.Container.WeaponHandler.DropWeapon();
            _weapon.GetRBody().AddTorque(Thrower.Container.Config.ThrowTwistedForce, ForceMode2D.Impulse);
        }
    }
}