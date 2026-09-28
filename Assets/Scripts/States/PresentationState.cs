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
    public BoatHandler CurrentEnemyInstance { get; private set; }

    [Header("Part 1")]
    [SerializeField] private CameraAngle meetUpAngle;
    [SerializeField] private AudioSource weoweoSound;
    [SerializeField] private AudioSource impactSound;

    [Header("Part 2")]
    [SerializeField] private CameraAngle boatViewAngle;

    protected override void StartState()
    {
        if(CurrentEnemyInstance != null) Destroy(CurrentEnemyInstance.gameObject);
        CurrentEnemyInstance = Instantiate(enemyBoatPrefabs.GetRandomOf(), enemyBoatStart.position, Quaternion.identity);

        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1);

        while(Vector3.Distance(orpheusBoat.transform.position, orpheusEnd.position) > 0.1f)
        {
            orpheusBoat.transform.position = Vector3.MoveTowards(orpheusBoat.transform.position, orpheusEnd.position, orpheusSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        TransitionManager.Instance.StartTransition(ETransition.Hmm);
        orpheusBoat.SurpriseAngle.CameraHandler.SetCameraHandle();
        weoweoSound.Play();

        yield return new WaitForSeconds(2.5f);

        TransitionManager.Instance.EndTransition(ETransition.Hmm);
        TransitionManager.Instance.StartTransition(ETransition.Versus);
        meetUpAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(0.2f);

        impactSound.Play();

        yield return new WaitForSeconds(0.8f);

        TransitionManager.Instance.EndTransition(ETransition.Versus);

        yield return new WaitForSeconds(1);

        TransitionManager.Instance.StartTransition(ETransition.AngryRev);
        CurrentEnemyInstance.SurpriseAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(2f);

        TransitionManager.Instance.StartTransition(ETransition.Angry);
        TransitionManager.Instance.EndTransition(ETransition.AngryRev);

        orpheusBoat.SurpriseAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(2f);

        TransitionManager.Instance.EndTransition(ETransition.Angry);

        TransitionManager.Instance.StartTransition(ETransition.BoatView);
        boatViewAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(5f);

        TransitionManager.Instance.EndTransition(ETransition.BoatView);
        meetUpAngle.CameraHandler.SetCameraHandle();
        
        GameManager.Instance.GameState = EGameState.Hold;
    }

    protected override void FinalizedState()
    {
        
    }
}