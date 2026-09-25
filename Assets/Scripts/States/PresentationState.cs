using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationState : State
{
    public override EGameState MyGameState => EGameState.Presentation;

    [SerializeField] private BoatHandler orpheusBoat;

    [Header("Enemy Boats")]
    [SerializeField] private Transform enemyBoatStart;
    [SerializeField] private List<BoatHandler> enemyBoatPrefabs = new List<BoatHandler>();
    private BoatHandler currentInstance;

    protected override void StartState()
    {
        if(currentInstance != null) Destroy(currentInstance.gameObject);
        currentInstance = Instantiate(enemyBoatPrefabs.GetRandomOf(), enemyBoatStart.position, Quaternion.identity);

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