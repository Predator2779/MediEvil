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
            Warrior.Weapon.DoDamage(Warrior.Data.Damage);
        }
        
        public override void Execute()
        {
            base.Execute();
            SafetyCompleting();
        }
    }
}