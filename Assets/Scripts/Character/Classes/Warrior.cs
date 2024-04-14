using System.Globalization;
using Character.ComponentContainer;
using Character.StateMachine.StateSets;
using Damageables.Weapon;

namespace Character.Classes
{
    public class Warrior : Person
    {
        public Weapon Weapon { get; set; }

        public delegate void Callback();
        public Callback OnEndedAttack;

        private WarriorStateSet _warriorStateSet;

        public Warrior(PersonContainer container, Weapon weapon) : base(container)
        {
            Weapon = weapon;
        }

        public override void Initialize()
        {
            base.Initialize();
            _warriorStateSet = new WarriorStateSet(this);
        }

        public void Attack() => Container.StateMachine.ChangeState(_warriorStateSet.AttackState);
        public void ComboAttack() => Container.StateMachine.ChangeState(_warriorStateSet.ComboAttackState);
        public void Defense() => Container.StateMachine.ChangeState(_warriorStateSet.DefenseState);
    }
}