using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationState : State
{
    public override EGameState MyGameState => EGameState.Presentation;

    [SerializeField] private BoatHandler orpheusBoat;
    [SerializeField] private Transform orpheusEnd;
    [SerializeField] private float orpheusSpeed = 5;

    [Header("Enemy Boats")]
    [SerializeField] private Transform enemyBoatStart;
    [SerializeField] private List<BoatHandler> enemyBoatPrefabs = new List<BoatHandler>();
    private BoatHandler currentInstance;

    [Header("Part 1")]
    [SerializeField] private CameraAngle surpriseAngle;
    [SerializeField] private CameraAngle meetUpAngle;

    protected override void StartState()
    {
        if(currentInstance != null) Destroy(currentInstance.gameObject);
        currentInstance = Instantiate(enemyBoatPrefabs.GetRandomOf(), enemyBoatStart.position, Quaternion.identity);

        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);

        while(Vector3.Distance(orpheusBoat.transform.position, orpheusEnd.position) > 0.01f)
        {
            orpheusBoat.transform.position = Vector3.MoveTowards(orpheusBoat.transform.position, orpheusEnd.position, orpheusSpeed * Time.deltaTime);
            yield return null;
        }

        TransitionManager.Instance.StartTransition(ETransition.Hmm);
        surpriseAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(1.3f);

        TransitionManager.Instance.EndTransition(ETransition.Hmm);
        meetUpAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(1);

        GameManager.Instance.GameState = EGameState.Hold;
    }

    protected override void FinalizedState()
    {
        
    }
}