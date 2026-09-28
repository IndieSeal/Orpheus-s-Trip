using System;
using System.Collections;
using UnityEngine;

public class EndState : State
{
    public override EGameState MyGameState => EGameState.End;

    public static event Action<bool> OnStartSink;

    [SerializeField] private CameraAngle middleAngle;
    private bool latestWinner;

    protected override void OnEnable()
    {
        base.OnEnable();

        GameManager.OnDecisionMade += SetLatestWinner;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        GameManager.OnDecisionMade -= SetLatestWinner;
    }

    protected override void StartState()
    {
        StartCoroutine(EyeDuelCoroutine());
    }

    protected override void FinalizedState()
    {
        
    }

    private void SetLatestWinner(bool t) => latestWinner = t;

    private IEnumerator EyeDuelCoroutine()
    {
        TransitionManager.Instance.StartTransition(ETransition.HalfHalf);
        yield return new WaitForSeconds(1.5f);

        // Enemy's eyes will convert into an X, and will start falling backwards
        OnStartSink?.Invoke(latestWinner);

        yield return new WaitForSeconds(0.3f);

        TransitionManager.Instance.EndTransition(ETransition.HalfHalf);
        middleAngle.CameraHandler.SetCameraHandle();

        yield return new WaitForSeconds(4f);
    }
}