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
            Warrior.Container.Movement.SetSideByVelocity();

            base.Execute();
            SafetyCompleting();
            CooldownControl();
        }

        public override void Exit()
        {
            base.Exit();
            OnEndedAttack();
        }

        protected float GetDamage()
        {
            var baseDamage = Warrior.Container.Config.Damage;
            return Mathf.Clamp(baseDamage * GetVelocityModificator(), baseDamage,
                baseDamage * GetVelocityModificator());
        }

        protected virtual void ApplyDamage()
        {
            var outputDamage = GetDamage();
            Warrior.Weapon.DoDamage(outputDamage);
            Warrior.Container.Stamina.Decrease(Warrior.Container.Config.StaminaAttackUsageCoef * outputDamage);
        }

        private float GetVelocityModificator() => Mathf.Abs(Warrior.Container.Movement.GetVelocity().x +
                                                            Warrior.Container.Movement.GetVelocity().y) *
                                                  GlobalConstants.VelocityDamageCoef;

        public override bool CanEnter() => Warrior.Weapon != null && Warrior.Container.Stamina.CanUse;
    }
}