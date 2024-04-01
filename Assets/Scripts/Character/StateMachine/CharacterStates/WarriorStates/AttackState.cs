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
            ApplyDamage();
        }

        public override void Execute()
        {
            Warrior.Movement.SetSideByVelocity();
            
            if (AnimationCompleted()) Warrior.Idle();

            base.Execute();
            SafetyCompleting();
            CooldownControl();
        }

        protected virtual float GetDamage()
        {
            var baseDamage = Warrior.Config.Damage;
            return Mathf.Clamp(baseDamage * GetVelocityModificator(), baseDamage,
                baseDamage * GetVelocityModificator());
        }

        protected void ApplyDamage()
        {
            var outputDamage = GetDamage();
            Warrior.Weapon.DoDamage(outputDamage);
            Warrior.Stamina.Decrease(Warrior.Config.StaminaAttackUsageCoef * outputDamage);
        }

        protected float GetVelocityModificator() => Mathf.Abs(Warrior.Movement.GetVelocity().x +
                                                              Warrior.Movement.GetVelocity().y) *
                                                    GlobalConstants.VelocityDamageCoef;

        public override bool CanEnter() => Warrior.Weapon != null && Warrior.Stamina.CanUse;
    }
}