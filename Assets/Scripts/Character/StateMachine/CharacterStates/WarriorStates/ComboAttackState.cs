using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates.WarriorStates
{
    public class ComboAttackState : AttackState
    {
        public ComboAttackState(Warrior warrior) : base(warrior)
        {
            Animation = "combo-attack";
        }

        protected override float GetDamage()
        {
            var baseDamage = Warrior.Config.Damage * Warrior.Config.ComboAttackDamageModificator;
            return Mathf.Clamp(baseDamage * GetVelocityModificator(), baseDamage,
                baseDamage * GetVelocityModificator());
        }
    }
}