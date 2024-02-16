using Character.StateMachine;
using Character.StateMachine.CharacterStates;

namespace Character.Classes
{
    public class Warrior : Person
    {
        // [field: SerializeField] public IDamageble Weapon { get; }

        public void ChangeState(CharacterState nextState)
        {
            StateMachine.ChangeState(nextState);
        }
    }
}