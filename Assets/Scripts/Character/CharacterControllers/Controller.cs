using Character.Classes;
using UnityEngine;

namespace Character.CharacterControllers
{
    [RequireComponent(typeof(Person))]
    public abstract class Controller : MonoBehaviour
    {
        protected Person Person { get; set; }
        
        private void Start() => Initialize();
        private void Update() => Execute();
        private void FixedUpdate() => FixedExecute();

        protected virtual void Initialize() => Person = GetComponent<Person>();

        protected virtual void Execute()
        {
            Person.StateMachine.Execute();
            CheckConditions();
        }
        protected virtual void FixedExecute() => Person.StateMachine.FixedExecute();
        protected virtual void CheckConditions() {}
    }
}