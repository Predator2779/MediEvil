using Character.Classes;
using Character.StateMachine;
using UnityEngine;

namespace Character.CharacterControllers.AI
{
    public class WarriorAI : Controller
    {
        public WarriorAI(CharacterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Execute()
        {
            base.Execute();

            AnalyseCondition();
        }

        private void AnalyseCondition()
        {
            if (Condition1())
            {
                StateMachine.ChangeState(StateMachine.IdleState);
            }
            else if (Condition2()) Debug.Log("Condition2");
            else if (Condition3()) Debug.Log("Condition3");
        }

        private bool Condition1() => false;
        private bool Condition2() => true;
        private bool Condition3() => false;
    }
}