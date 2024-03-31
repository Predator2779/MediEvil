using Character.Classes;
using UnityEngine;

namespace Character.CharacterControllers
{
    [RequireComponent(typeof(Person))]
    public abstract class Controller : MonoBehaviour
    {
        protected Person _person;

        private void Start() => Initialize();
        private void Update() => Execute();
        private void FixedUpdate() => FixedExecute();

        protected virtual void Initialize() => _person = GetComponent<Person>();
        protected virtual void Execute() => _person.StateMachine.Execute();
        protected virtual void FixedExecute() => _person.StateMachine.FixedExecute();
    }
}