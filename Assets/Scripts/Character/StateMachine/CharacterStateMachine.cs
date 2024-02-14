namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        private CharacterState _currentState;

        public void ChangeState(CharacterState newCharacterState)
        {
            _currentState?.Exit();
            _currentState = newCharacterState;
            _currentState.Enter();
        }

        public void ExecuteState() => _currentState.Execute();
    }
}

// Base State

// Состояния

// Персонаж

// Пример использования
/*
State initialState = new IdleState();
Person warrior = new Person(initialState);

warrior.HandleInput("idle"); // Персонаж переходит в режим покоя
warrior.HandleInput("attack"); // Персонаж атакует
*/
