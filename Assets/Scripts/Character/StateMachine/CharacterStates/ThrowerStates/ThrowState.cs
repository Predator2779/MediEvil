using Character.Classes;
using Character.StateMachine.CharacterStates.WarriorStates;

namespace Character.StateMachine.CharacterStates.ThrowerStates
{
    public class ThrowState : WarriorState
    {
        public ThrowState(Warrior warrior) : base(warrior)
        {
            Animation = "throw";
        }
    }
}