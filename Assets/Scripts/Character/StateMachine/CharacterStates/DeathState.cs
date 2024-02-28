using Character.Classes;
using UnityEngine;

namespace Character.StateMachine.CharacterStates
{
    public class DeathState : CharacterState
    {
        public DeathState(Person person) : base(person)
        {
            Animation = "death";
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("You Died.");
        }

        public override void Execute() => SafetyCompleting();

        public override void FixedExecute()
        {
        }

        public override void Exit()
        {
            if (AnimationCompleted()) Die();
            base.Exit();
        }

        private void Die()
        {
            if (!Person.IsPlayer) Person.gameObject.SetActive(false);
            else Debug.Log("Respawn...");
        }
    }
}