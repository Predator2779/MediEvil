using Character.StateMachine;

namespace Character.Classes
{
    public class Warrior : Person2
    {
        // [field: SerializeField] public IDamageble Weapon { get; }
        
        public Warrior(CharacterState initialCharacterState)
        {
            StateMachine = new CharacterStateMachine();
            StateMachine.ChangeState(initialCharacterState);
        }

        public void ChangeState(CharacterState nextState)
        {
            StateMachine.ChangeState(nextState);
        }
    }
}