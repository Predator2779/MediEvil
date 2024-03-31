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
        
        protected override void Execute()
        {
            _person.StateMachine.Execute();
            
            SetTempDirection();

            if (CanAttack())
            {
                t = Attack;
                if (!delay) StartCoroutine(OneShot());
                // Attack();
            }
            
            if (CanFollow())
            {
                Follow();
                return;
            }

            Idle();
        }

        private bool CanAttack() => Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);
        private void Attack() => _warrior.Attack();
    }
}