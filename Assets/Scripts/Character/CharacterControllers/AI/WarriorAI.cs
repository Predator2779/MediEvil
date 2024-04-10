using Character.Classes;
using Character.ComponentContainer;
using Global;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : PersecutorAI
    {
        private Warrior _warrior;
        private bool _staminaRestore;

        public WarriorAI(PersonContainer container, ScopeCoverage scopeCoverage) : base(container, scopeCoverage)
        {
            _warrior = new Warrior(container, null);
        }
        
        public void SetWarrior(Warrior warrior) => _warrior = warrior;
        
        public override void Initialize()
        {
            base.Initialize();
            Debug.Log(_warrior?.Container.Config.Name);
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
            if (_person?.Container.Stamina.GetPercentageRation() > 30) _staminaRestore = false; // написать конфиг для ИИ
            if (_person?.Container.Stamina.GetPercentageRation() <= 0) _staminaRestore = true;
        }
        
        private void Attack()
        {
            if (Random.Range(0, GlobalConstants.ComboChanceAI) == 0) _warrior.Attack(); 
            else _warrior.ComboAttack();
        }

        private bool CanAttack() => GetTargetDistance() <= _stayDistance;
    }
}