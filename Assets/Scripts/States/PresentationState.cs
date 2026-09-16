using System.Collections;
using UnityEngine;

public class PresentationState : State
{
    public override EGameState MyGameState => EGameState.Presentation;

    protected override void StartState()
    {
        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.GameState = EGameState.Hold;
    }

    protected override void FinalizedState()
    {
        
    }
}