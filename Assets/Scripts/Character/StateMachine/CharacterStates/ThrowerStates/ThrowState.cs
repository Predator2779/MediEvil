using Character.Classes;
using Damageables.Weapons;
using UnityEngine;

namespace Character.StateMachine.CharacterStates.ThrowerStates
{
    public class ThrowState : TiredState
    {
        protected Thrower Thrower { get; }
        
        protected Weapon _weapon;
        
        public ThrowState(Thrower thrower) : base(thrower.Container)
        {
            Thrower = thrower;
        }

        public override void Enter()
        {
            base.Enter();
            Throw();
        }

        protected virtual void Throw()
        {
            _weapon = Thrower.Container.WeaponHandler.CurrentWeapon;
            
            if (_weapon == null) return;
            
            Thrower.Container.WeaponHandler.DropWeapon();
            _weapon.GetRBody().AddForce(GetThrowVector() * Thrower.Container.Config.ThrowForce, ForceMode2D.Impulse);
        }

        private Vector2 GetThrowVector() => Thrower.Container.transform.right * Mathf.Sign(Thrower.Container.transform.rotation.y);
    }
}