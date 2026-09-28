using UnityEngine;

public class WinState : State
{
    public override EGameState MyGameState => EGameState.Won;

    protected override void StartState()
    {
        Debug.Log("Woah! You did it! YOU WON (just this fight)");
    }

    protected override void FinalizedState()
    {
        
    }
}