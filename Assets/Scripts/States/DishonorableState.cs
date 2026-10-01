using System;
using System.Collections;
using UnityEngine;

public class DishonorableState : State
{
    public override EGameState MyGameState => EGameState.Dishonored;

    public static event Action OnStartDishonorableCharge;
    public static event Action<bool> OnEndDishonorableCharge;

    [SerializeField] private AudioSource singleShotSource;
    [SerializeField] private AudioSource explosionSource;

    protected override void StartState()
    {
        StartCoroutine(DishonoredCoroutine());
    }

    protected override void FinalizedState()
    {
        
    }

    private IEnumerator DishonoredCoroutine()
    {
        singleShotSource.Play();
        
        TransitionManager.Instance.StartTransition(ETransition.Fade);
        TransitionManager.Instance.EndTransition(ETransition.Fade);

        yield return new WaitForSeconds(1f);

        TransitionManager.Instance.StartTransition(ETransition.Dishonorable);
        
        yield return new WaitForSeconds(13f);

        TransitionManager.Instance.StartTransition(ETransition.Fade);
        TransitionManager.Instance.EndTransition(ETransition.Fade);

        yield return new WaitForSeconds(1f);
        TransitionManager.Instance.EndTransition(ETransition.Dishonorable, disableObject: true);

        OnStartDishonorableCharge?.Invoke();

        yield return new WaitForSeconds(0.7f);

        explosionSource.Play();

        yield return new WaitForSeconds(4.3f);

        OnEndDishonorableCharge?.Invoke(false);

        TransitionManager.Instance.StartTransition(ETransition.Fade);
        TransitionManager.Instance.EndTransition(ETransition.Fade);

        yield return new WaitForSeconds(1f);
        
        TransitionManager.Instance.StartTransition(ETransition.Lose);
    }
}