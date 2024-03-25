using System;
using Character.Classes;
using UnityEngine;

namespace Character.CharacterControllers
{
    [RequireComponent(typeof(Person))]
    public abstract class Controller : MonoBehaviour
    {
        protected Person Person { get; set; }

        private void OnValidate() => Initialize();
        private void Start() => Initialize();
        private void Update() => Execute();
        private void FixedUpdate() => FixedExecute();

        protected virtual void Initialize()
        {
            Person = GetComponent<Person>();
            Person.Initialize();
        }

        protected virtual void Execute()
        {
            CheckConditions();
            Person.Execute();
        }

        protected virtual void FixedExecute() => Person.FixedExecute();
        protected virtual void CheckConditions() {}
    }
}