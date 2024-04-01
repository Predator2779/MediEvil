using Character.Classes;
using Character.StateMachine.CharacterStates.WarriorStates;

namespace Character.StateMachine.StateSets
{
    public class WarriorStateSet : PersonStateSet
    {
        public AttackState AttackState { get; }
        public ComboAttackState ComboAttackState { get; }

        public WarriorStateSet(Warrior warrior) : base(warrior)
        {
            AttackState = new AttackState(warrior);
            ComboAttackState = new DoubleStrikeAttackState(warrior);
        }
    }
}