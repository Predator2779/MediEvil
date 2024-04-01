using System.Collections;
using Character.Classes;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        private Warrior _warrior;
        private bool _canCombo;
        
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

            _warrior.Movement.LookTo(_target.transform);
            
            if (_person.Stamina.GetPercentageRation() <= 15)
            {
                WalkFollow();
                return;
            } 
            
            if (CanAttack() && _canCombo)
            {
                ComboAttack();
                return;
            }
            
            if (CanAttack())
            {
                Attack();
                return;
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
        
        private void ComboAttack()
        {
            _warrior.ComboAttack();
            _canCombo = true;
            StopCoroutine(ResetCombo());
            StartCoroutine(ResetCombo());
        }
        
        private void Attack()
        {
            _warrior.Attack();
            _canCombo = true;
            StopCoroutine(ResetCombo());
            StartCoroutine(ResetCombo());
        }
        private IEnumerator ResetCombo()
        {
            yield return new WaitForSeconds(_warrior.Config.ComboInterval);
            _canCombo = false;
        }
        
        private bool CanAttack() => GetTargetDistance() <= _stayDistance;
    }
}