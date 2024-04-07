using Character.Classes;
using Global;
using UnityEngine;
using Zenject;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        [Inject] private Warrior _warrior;
        private bool _staminaRestore;

        public override void Initialize()
        {
            base.Initialize();
            _warrior = GetComponent<Warrior>();
        }

        public override void Execute()
        {
            _person.StateMachine.Execute();

            SetTempDirection();
            StaminaControl();
            
            if (!HasTarget())
            {
                Idle();
                return;
            }

            _warrior.Container.Movement.LookTo(_target.transform);
            
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
            if (_person.Container.Stamina.GetPercentageRation() > 30) _staminaRestore = false; // написать конфиг для ИИ
            if (_person.Container.Stamina.GetPercentageRation() <= 0) _staminaRestore = true;
        }
        
        private void Attack()
        {
            if (Random.Range(0, GlobalConstants.ComboChanceAI) == 0) _warrior.Attack(); 
            else _warrior.ComboAttack();
        }

        private bool CanAttack() => GetTargetDistance() <= _stayDistance;
    }
}