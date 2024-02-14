using System;
using Character.StateMachine;

public class AttackCharacterState : CharacterState
{
    public override void Enter()
    {
        Console.WriteLine("Entering Attack State");
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Exit()
    {
        Console.WriteLine("Exiting Attack State");
    }
}