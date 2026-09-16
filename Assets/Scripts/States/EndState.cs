using UnityEngine;

public class EndState : State
{
    public override EGameState MyGameState => EGameState.End;

    protected override void StartState()
    {
        
    }
    
    protected override void FinalizedState()
    {
        
    }
}