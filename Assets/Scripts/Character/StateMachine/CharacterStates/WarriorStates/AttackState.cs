using Character.Classes;
using Global;
using UnityEngine;

namespace Character.StateMachine.CharacterStates.WarriorStates
{
    public class AttackState : WarriorState
    {
        public AttackState(Warrior warrior) : base(warrior)
        {
            Animation = "attack";
        }

        public override void Enter()
        {
            base.Enter();
            var baseDamage = Warrior.Config.Damage;
            var outputDamage = 
                Mathf.Clamp(baseDamage * GetVelocityModificator(), baseDamage,
                baseDamage * GetVelocityModificator());
            
            Warrior.Weapon.DoDamage(outputDamage);
            Warrior.Stamina.Decrease(Warrior.Config.StaminaAttackUsageCoef * outputDamage);
        }
        
        public override void Execute()
        {
            if (AnimationCompleted()) Warrior.Idle();
            
            base.Execute();
            SafetyCompleting();
            CooldownControl();
        }

        private float GetVelocityModificator() => Mathf.Abs(Warrior.Movement.GetVelocity().x +
                                                            Warrior.Movement.GetVelocity().y) * 
                                                  GlobalConstants.VelocityDamageCoef;
        public override bool CanEnter() => Warrior.Weapon != null && Warrior.Stamina.CanUse;
    }
}