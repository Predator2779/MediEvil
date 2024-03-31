using Character.Classes;

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
            Warrior.Weapon.DoDamage(Warrior.Data.Damage);
        }
        
        public override void Execute()
        {
            if (AnimationCompleted()) Warrior.Idle();
            
            base.Execute();
            SafetyCompleting();
            CooldownControl();
        }

        public override bool CanEnter() => Warrior.Weapon != null && Warrior.Stamina.CanUse;
    }
}