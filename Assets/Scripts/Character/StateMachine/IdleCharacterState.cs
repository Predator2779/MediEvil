using System;
using Character.StateMachine;

public class IdleCharacterState : CharacterState
{
    public override void Enter()
    {
        Console.WriteLine("Entering Idle State");
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Exit()
    {
        Console.WriteLine("Exiting Idle State");
    }
}