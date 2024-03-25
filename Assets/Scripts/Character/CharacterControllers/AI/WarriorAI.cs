using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        protected override void CheckConditions()
        {
            SetTempDirection();
            
            if (CanAttack()) return;
            if (CanFollow()) return;
            
            Person.Idle();
        }

        private bool CanAttack()
        {
            var collider = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);
            if (!collider) return false;
            
            Person.Idle();
            return true;
        } 
    }
}