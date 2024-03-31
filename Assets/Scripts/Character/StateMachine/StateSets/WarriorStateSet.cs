using Character.Classes;
using Character.StateMachine.CharacterStates.WarriorStates;

namespace Character.StateMachine.StateSets
{
    public class WarriorStateSet : PersonStateSet
    {
        private readonly Warrior _warrior;
        public AttackState AttackState { get; }

        public WarriorStateSet(Warrior warrior) : base(warrior)
        {
            _warrior = warrior;
            AttackState = new AttackState(_warrior);
        }
    }
}