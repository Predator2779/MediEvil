using Character.ComponentContainer;
using Character.Configs;
using Character.Interaction;
using Character.Movement;
using Damageables.Weapons;
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

        private void StartCreator()
        {
            InstantiateUnitComponents();
            SetController();
            Initialize();
            
            Destroy(gameObject);
        }
        protected abstract void InstantiateUnitComponents();
        protected abstract void SetController();
        private void Initialize() => _container.Initialize();
        
        protected void CreateUnit() => _unit = Instantiate(
            _unitPrefabBase,
            transform.position, 
            Quaternion.identity, 
            _path);

        protected void CreateContainer()
        {
            _container = _unit.AddComponent<PersonContainer>();
            SetFields(_container);
        }

        protected virtual void SetFields(PersonContainer personContainer)
        {
            // var unit = _unitPrefabBase;
            
            personContainer.Config ??= _config;
            personContainer.Movement ??= _unit.AddComponent<CharacterMovement>();
            personContainer.Animator ??= _unit.GetComponent<Animator>();
            personContainer.ItemHandler ??= _unit.GetComponentInChildren<ItemHandler>();
            personContainer.WeaponHandler ??= _unit.GetComponentInChildren<WeaponHandler>();
        }

        protected Weapon GetWeapon()
        {
            var weapon = _unit.GetComponentInChildren<Weapon>();
            return weapon != null ? weapon : null;
        }
    }
}