using Character.Classes;

namespace Character.StateMachine.CharacterStates.WarriorStates
{
    public class DoubleStrikeAttackState : ComboAttackState
    {
        private int _frames;

        public DoubleStrikeAttackState(Warrior warrior) : base(warrior)
        {
            Animation = "combo-attack";
        }

        public override void Execute()
        {
            base.Execute();
            SecondStrike();
        }

        private void SecondStrike()
        {
            _frames++;
            if (_frames < Warrior.Config.SecondStrikeDelay) return;
            
            _frames = 0;
            ApplyDamageWithoutStamina();
        }

        private void ApplyDamageWithoutStamina()
        {
            var outputDamage = GetDamage();
            Warrior.Weapon.DoDamage(outputDamage);
        }
        
    }
}