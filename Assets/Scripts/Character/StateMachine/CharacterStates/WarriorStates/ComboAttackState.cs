using Character.Classes;
using Global;

namespace Character.StateMachine.CharacterStates.WarriorStates
{
    public class ComboAttackState : AttackState
    {
        public ComboAttackState(Warrior warrior) : base(warrior)
        {
            Animation = "combo-attack";
        }

        protected override void ApplyDamage()
        {
            var outputDamage = GetDamage() * Warrior.Config.ComboAttackDamageModificator;
            Warrior.Weapon.DoDamage(outputDamage);
            Warrior.Stamina.Decrease(Warrior.Config.StaminaAttackUsageCoef * outputDamage / GlobalConstants.StaminaComboDivider);
        }
    }
}