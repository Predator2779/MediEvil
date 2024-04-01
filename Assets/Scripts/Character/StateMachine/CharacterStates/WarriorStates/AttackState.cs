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
            Warrior.Stamina.Decrease(Warrior.Data.StaminaAttackUsage);
            Warrior.Weapon.DoDamage(Mathf.Clamp(Warrior.Data.Damage * GetVelocityModificator(), Warrior.Data.Damage, Warrior.Data.Damage * GetVelocityModificator()));
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