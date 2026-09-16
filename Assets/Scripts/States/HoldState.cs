using System.Collections;
using UnityEngine;

public class HoldState : State
{
    public override EGameState MyGameState => EGameState.Hold;

    protected override void StartState()
    {
        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.GameState = EGameState.Shoot;
    }

    protected override void FinalizedState()
    {
        
    }
}