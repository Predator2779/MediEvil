using Character.Classes;
using Character.StateMachine;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        protected override void Initialize()
        {
            _person = GetComponent<Warrior>(); ////////////////////
            _person.SetStateMachine(new WarriorStateMachine((Warrior)_person));
        }
        
        protected override void CheckConditions()
        {
            SetTempDirection();

            if (CanAttack()) return;
            if (CanFollow()) return;

            _person.Idle();
        }

        private bool CanAttack()
        {
            var collider = Physics2D.OverlapCircle(GetCapsuleCenterPos(), _attackRadius, _layerMask);
            if (!collider) return false;

            _person.Idle();
            return true;
        }
    }
}