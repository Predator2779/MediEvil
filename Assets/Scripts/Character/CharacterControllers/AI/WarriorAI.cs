using Character.Classes;
using Global;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        private Warrior _warrior;
        private bool _staminaRestore;

        protected override void Initialize()
        {
            base.Initialize();
            _warrior = GetComponent<Warrior>();
        }

        protected override void Execute()
        {
            _person.StateMachine.Execute();

            SetTempDirection();
            StaminaControl();
            
            if (!HasTarget())
            {
                Idle();
                return;
            }

            _warrior.Movement.LookTo(_target.transform);
            
            if (_staminaRestore)
            {
                if (CanStay())
                {
                    Idle();
                    return;
                }
                
                WalkFollow();
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

        private void StaminaControl()
        {
            if (_person.Stamina.GetPercentageRation() > 30) _staminaRestore = false; // написать конфиг для ИИ
            if (_person.Stamina.GetPercentageRation() <= 0) _staminaRestore = true;
        }
        
        private void Attack()
        {
            if (Random.Range(0, GlobalConstants.ComboChanceAI) == 0) _warrior.Attack(); 
            else _warrior.ComboAttack();
        }

        private bool CanAttack() => GetTargetDistance() <= _stayDistance;
    }
}