using Character.ComponentContainer;
using Character.StateMachine.StateSets;
using Damageables.Weapon;

namespace Character.Classes
{
    public class Warrior : Person
    {
        public Weapon Weapon { get; set; }

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

        public void Attack() =>  StateMachine.ChangeState(_warriorStateSet.AttackState);
        public void ComboAttack() =>  StateMachine.ChangeState(_warriorStateSet.ComboAttackState);
        public void Defense() =>  StateMachine.ChangeState(_warriorStateSet.DefenseState);
    }
}