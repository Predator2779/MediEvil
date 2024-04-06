using UnityEngine;

namespace Builders
{
    public interface IUnitBuilder
    {
        public void BuildWarrior();
        public void BuildThrower();
        public void BuildMage();
        public GameObject GetResult();
    }
}