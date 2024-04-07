using Character.Classes;
using Character.ComponentContainer;
using Character.StateMachine.CharacterStates.WarriorStates;

namespace Character.StateMachine.StateSets
{
    public class WarriorStateSet : PersonStateSet
    {
        public AttackState AttackState { get; }
        public ComboAttackState ComboAttackState { get; }
        public DefenseState DefenseState { get; }

        public WarriorStateSet(Warrior warrior) : base(warrior)
        {
            AttackState = new AttackState(warrior);
            ComboAttackState = new DoubleStrikeAttackState(warrior);
            DefenseState = new DefenseState(warrior);
        }
    }
}