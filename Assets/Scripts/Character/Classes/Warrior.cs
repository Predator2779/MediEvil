using Character.Movement;
using Character.StateMachine.StateSets;
using Character.ValueStorages;
using Damageables.Weapon;
using UnityEngine;

namespace Character.Classes
{
    public class Warrior : Person
    {
        [field: SerializeField] public Weapon Weapon { get; set; }
        
        private WarriorStateSet _warriorStateSet;

        protected override void Initialize()
        {
            base.Initialize();
            _warriorStateSet = new WarriorStateSet(this);
        }

        public void Attack() => StateMachine.ChangeState(_warriorStateSet.AttackState);
    }
}