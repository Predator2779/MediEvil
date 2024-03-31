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

            if (CanAttack())
            {
                Attack();
                return;
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