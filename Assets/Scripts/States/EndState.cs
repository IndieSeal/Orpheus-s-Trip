using UnityEngine;

public class EndState : State
{
    public override EGameState MyGameState => EGameState.EndDumb;

    protected override void StartState()
    {
        // Because you didn't wait for the SHOOT notif. so you are dishonorable (you shot early)
        Debug.Log("You lost, and DISHONORABLY, YOU SHOULD BE ASHAMED OF YOURSELF");
    }
    
    protected override void FinalizedState()
    {
        
    }
}