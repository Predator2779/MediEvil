using Character;
using Character.CharacterControllers;
using Character.Classes;
using Character.ComponentContainer;
using UI;
using UnityEngine;

namespace Builders
{
    public class UnitBuilder
    {
        private GameObject _unit;
        private PersonContainer _personContainer;
        private readonly CharacterConfig _config;
        private readonly ValueBarContainer _barContainer;

        public UnitBuilder(
            GameObject baseObject,
            CharacterConfig config,
            ValueBarContainer barContainer)
        {
            _unit = baseObject;
            _config = config;
            _barContainer = barContainer;
        }

        public UnitBuilder BuildWarrior()
        {
            _personContainer = SetFields(_personContainer);
            return this;
        }

        public UnitBuilder BuildThrower()
        {
            return this;
        }

        public UnitBuilder BuildMage()
        {
            return this;
        }

        public GameObject GetResult() => _unit;

        private PersonContainer SetFields(PersonContainer personContainer)
        {
            personContainer.Config = _config;
            
            personContainer.HealthBar = _barContainer.HealthBar;
            personContainer.StaminaBar = _barContainer.StaminaBar;
            personContainer.ManaBar = _barContainer.ManaBar;
            
            return personContainer;
        }
    }
}