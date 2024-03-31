using Character.Classes;
using Character.StateMachine.StateSets;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        private Warrior _warrior;

        protected override void Initialize() => _warrior = GetComponent<Warrior>();
        
        protected override void Execute()
        {
            SetTempDirection();

            if (CanAttack())
            {
                Attack();
                return;
            }
            
            if (CanFollow()) return;

            Idle();
        }

        private bool CanAttack() => Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);
        private void Attack() => _warrior.Attack();
    }
}