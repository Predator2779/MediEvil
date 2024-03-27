using Character.Classes;

namespace Character.StateMachine.CharacterStates.WarriorStates
{
    public class WarriorState : CharacterState
    {
        protected Warrior Warrior { get; }
        
        public WarriorState(Warrior warrior) : base(warrior)
        {
            // Person = warrior;
            Warrior = warrior;
        }
    }
}