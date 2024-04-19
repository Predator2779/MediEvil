using Character.ComponentContainer;
using Character.StateMachine.StateSets;
using Damageables.Weapons;
using Global;

namespace Character.Classes
{
    public class Warrior : Person
    {
        public Weapon Weapon { get; set; }
        
        public GlobalConstants.Callback OnEndedAttack;

        private WarriorStateSet _warriorStateSet;

        public Warrior(PersonContainer container) : base(container)
        {
            Weapon = container.WeaponHandler.CurrentWeapon;
        }

        public override void Initialize()
        {
            base.Initialize();
            _warriorStateSet = new WarriorStateSet(this);
        }

        public void Attack() => Container.StateMachine.ChangeState(_warriorStateSet.AttackState);
        public void ComboAttack() => Container.StateMachine.ChangeState(_warriorStateSet.ComboAttackState);
        public void CombatSlide() => Container.StateMachine.ChangeState(_warriorStateSet.CombatSlideState);
        public void Defense() => Container.StateMachine.ChangeState(_warriorStateSet.DefenseState);
    }
}