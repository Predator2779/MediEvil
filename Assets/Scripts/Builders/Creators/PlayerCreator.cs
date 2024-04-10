using Character.CharacterControllers;
using Character.CharacterControllers.Inputs;
using Character.ComponentContainer;
using Other.Follow;
using UI;
using UnityEngine;

namespace Builders.Creators
{
    public class PlayerCreator : AbstractUnitCreator
    {
        // [SerializeField] protected GameObject _parentPrefab;
        [SerializeField] protected Following _cameraPrefab;
        [SerializeField] protected ValueBarContainer _barContainer;

        protected override void StartCreator()
        {
            CreateUnit();
            SetController(new InputController(_container));
            CreateCamera();
            Destroy(gameObject);
        }

        private void CreateCamera()
        {
            // var parent = Instantiate(_parentPrefab, transform.position, Quaternion.identity, _path);
            var camera = Instantiate(_cameraPrefab, transform.position + _cameraPrefab.transform.position, Quaternion.identity, _path);
            camera.Target = _unit.transform;
            
            // _unit.transform.position = parent.transform.position;
            // _unit.transform.parent = parent.transform;
        }

        protected override void SetFields(PersonContainer personContainer)
        {
            base.SetFields(personContainer);

            personContainer.HealthBar = _barContainer.HealthBar;
            personContainer.StaminaBar = _barContainer.StaminaBar;
            personContainer.ManaBar = _barContainer.ManaBar;
        }
    }
}