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

        private void SecondStrike()
        {
            _frames++;
            if (_frames < Warrior.Config.SecondStrikeDelay) return;
            
            _frames = 0;
            ApplyDamage();
        }

        public override void Execute()
        {
            base.Execute();
            SecondStrike();
        }
    }
}