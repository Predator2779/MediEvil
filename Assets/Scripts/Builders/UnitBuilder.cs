using Character;
using Character.CharacterControllers;
using Character.Classes;
using UI;
using UnityEngine;

namespace Builders
{
    public class UnitBuilder
    {
        private GameObject _unit;
        private Person _person;
        private readonly CharacterConfig _config;
        private readonly Controller _controller;
        private readonly ValueBarContainer _barContainer;

        public UnitBuilder(
            GameObject baseObject,
            CharacterConfig config,
            Controller controller,
            ValueBarContainer barContainer)
        {
            _unit = baseObject;
            _config = config;
            _controller = controller;
            _barContainer = barContainer;
        }

        public UnitBuilder BuildWarrior()
        {
            _person = _unit.AddComponent<Warrior>();
            _person = SetFields(_person);
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

        private Person SetFields(Person person)
        {
            person.Config = _config;
            
            person.HealthBar = _barContainer.HealthBar;
            person.StaminaBar = _barContainer.StaminaBar;
            person.ManaBar = _barContainer.ManaBar;
            
            return person;
        }
    }
}