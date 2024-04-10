using Character;
using Character.CharacterControllers;
using Character.CharacterControllers.AI;
using Character.CharacterControllers.Inputs;
using Character.ComponentContainer;
using Character.Movement;
using UI;
using UnityEngine;

namespace Builders.Creators
{
    public abstract class AbstractUnitCreator : MonoBehaviour
    {
        [SerializeField] protected GameObject _unitPrefabBase;
        [SerializeField] protected Transform _path;
        [SerializeField] protected CharacterConfig _config;

        protected GameObject _unit;
        protected PersonContainer _container;

        private void Awake() => StartCreator();
        protected abstract void StartCreator();
        protected virtual void CreateUnit()
        {
            _unit = Instantiate(_unitPrefabBase, transform.position, Quaternion.identity, _path);
            _container = _unit.AddComponent<PersonContainer>();

            SetFields(_container); ;
        }

        protected void SetController(Controller controller) => _container.Controller = controller;

        protected virtual void SetFields(PersonContainer personContainer)
        {
            personContainer.Config ??= _config;
            personContainer.Movement ??= _unit.AddComponent<CharacterMovement>();
        }
    }
}