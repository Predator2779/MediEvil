using Character;
using Character.CharacterControllers;
using UI;
using UnityEngine;

namespace Builders
{
    public class UnitDirector : MonoBehaviour
    {
        [SerializeField] private bool _isWarrior, _isThrower, _isMage;
        [SerializeField] private Controller _controller;
        [SerializeField] private GameObject _prefabBase;
        [SerializeField] private Transform _parent;
        [SerializeField] private CharacterConfig _config;
        [SerializeField] private ValueBarContainer _barContainer;
        
        private UnitBuilder _builder;

        private void Awake()
        {
            _builder = new UnitBuilder(_prefabBase, _config, _barContainer);
            Instantiate(CreateUnit(), transform.position, Quaternion.identity, _parent);
            Destroy(gameObject);
        }

        private GameObject CreateUnit()
        {
            if (_isWarrior) _builder.BuildWarrior();
            if (_isThrower) _builder.BuildThrower();
            if (_isMage) _builder.BuildMage();

            return _builder.GetResult();
        }
    }
}