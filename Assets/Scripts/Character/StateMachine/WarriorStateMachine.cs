using Character.Classes;
using Character.StateMachine.CharacterStates.WarriorStates;

namespace Character.StateMachine
{
    public class WarriorStateMachine : PersonStateMachine
    {
        private readonly Warrior _warrior;
        public AttackState AttackState { get; }

        public WarriorStateMachine(Warrior warrior) : base(warrior)
        {
            _warrior = warrior;
            AttackState = new AttackState(_warrior);
        }
    }
}