using System.Collections;
using Character.Classes;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        private Warrior _warrior;

        protected override void Initialize()
        {
            base.Initialize();
            _warrior = GetComponent<Warrior>();
        }

        protected override void Execute()
        {
            _person.StateMachine.Execute();

            SetTempDirection();
            
            if (!HasTarget())
            {
                Idle();
                return;
            }

            if (CanAttack())
            {
                t = Attack;
                if (!delay) StartCoroutine(OneShot());
                // Attack();
            }

            if (CanWalkFollow())
            {
                WalkFollow();
                return;
            }  
            
            if (CanRunFollow())
            {
                RunFollow();
            }
        }
        
        delegate void T();
        private T t;
        private bool delay;

        protected IEnumerator OneShot()
        {
            t();
            delay = true;
            yield return new WaitForSeconds(2);
            delay = false;
        }

        private bool CanAttack() => GetTargetDistance() <= _stayDistance;
        private void Attack() => _warrior.Attack();
    }
}