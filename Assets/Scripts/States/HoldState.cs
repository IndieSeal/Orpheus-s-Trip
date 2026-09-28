using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class HoldState : State
{
    public override EGameState MyGameState => EGameState.Hold;

    [SerializeField, MinMaxSlider(0f, 5f)] private Vector2 minMaxTime = new Vector2(0.3f, 2f);

    protected override void StartState()
    {
        UserInput.ShootPressed += Shoot;

        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(minMaxTime.x, minMaxTime.y));
        GameManager.Instance.GameState = EGameState.Shoot;
    }

    protected override void FinalizedState()
    {
        StopAllCoroutines();
        UserInput.ShootPressed -= Shoot;
    }

    private void Shoot()
    {
        GameManager.Instance.GameState = EGameState.EndDumb;
    }
}