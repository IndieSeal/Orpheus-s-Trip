using UnityEngine;

public class LostState : State
{
    public override EGameState MyGameState => EGameState.Lost;

    protected override void StartState()
    {
        Debug.Log("I'm sorry, but your run is over :[");
    }

    protected override void FinalizedState()
    {
        
    }
}