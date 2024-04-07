using System;
using Character.Classes;
using Character.ComponentContainer;
using UnityEngine;
using Zenject;

namespace Character.CharacterControllers
{
    public abstract class Controller : MonoBehaviour, IController
    {
        [Inject] protected Person _person;

        private void Awake() => Initialize();
        private void Update() => Execute();
        private void FixedUpdate() => FixedExecute();
        
        public virtual void Initialize() {}
        public virtual void Execute() => _person.StateMachine.Execute();
        public virtual void FixedExecute() => _person.StateMachine.FixedExecute();
    }
}