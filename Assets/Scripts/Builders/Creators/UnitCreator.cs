using System;
using Character.CharacterControllers.AI;
using Character.ComponentContainer;
using UI;
using UnityEngine;

namespace Builders.Creators
{
    public class UnitCreator : AbstractUnitCreator
    {
        [SerializeField] private TypeController _controller;
        [SerializeField] private ValueBarContainer _prefabBarContainer;

        private ScopeCoverage _scopeCoverage;

        protected override void StartCreator()
        {
            _scopeCoverage = GetComponent<ScopeCoverage>();
            
            switch (_controller)
            {
                case TypeController.PersecutorAI:
                    CreateUnit();
                    SetController(new PersecutorAI(_container, _scopeCoverage));
                    Destroy(gameObject);
                    break;
                case TypeController.WarriorAI:
                    CreateUnit();
                    SetController(new PersecutorAI(_container, _scopeCoverage));
                    Destroy(gameObject);
                    break;
                case TypeController.BattleMageAI:
                    CreateUnit();
                    SetController(new BattleMageAI(_container));
                    Destroy(gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void SetFields(PersonContainer personContainer)
        {
            base.SetFields(personContainer);

            var barContainer = _unitPrefabBase.GetComponentInChildren<ValueBarContainer>();

            if (barContainer == null)
            {
                barContainer = Instantiate(
                    _prefabBarContainer,
                    _unit.transform.position,
                    Quaternion.identity,
                    _unit.transform);
            }

            personContainer.HealthBar = barContainer.HealthBar;
            personContainer.StaminaBar = barContainer.StaminaBar;
            personContainer.ManaBar = barContainer.ManaBar;
        }

        private enum TypeController
        {
            PersecutorAI,
            WarriorAI,
            BattleMageAI
        }
    }
}