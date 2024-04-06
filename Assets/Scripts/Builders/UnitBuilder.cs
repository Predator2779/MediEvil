using Character;
using Character.Movement;
using Character.ValueStorages;
using Character.ValueStorages.Bars;
using UnityEditor.Animations;
using UnityEngine;

namespace Builders
{
    public class UnitBuilder : IUnitBuilder
    {
        private GameObject _unit;

        public UnitBuilder(
            CharacterConfig config,
            AnimatorController animController, 
            ValueBar healthBar)
        {
            // capsule?
            // rbody??
            
            // или сделать базовый каркас для инстанцирования префаба в котором будут основные общие элементы
        }
        
        public void BuildWarrior()
        {
            throw new System.NotImplementedException();
        }

        public void BuildThrower()
        {
            throw new System.NotImplementedException();
        }

        public void BuildMage()
        {
            throw new System.NotImplementedException();
        }

        public GameObject GetResult()
        {
            throw new System.NotImplementedException();
        }
    }
}