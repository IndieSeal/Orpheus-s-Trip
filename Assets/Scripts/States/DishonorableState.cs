using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DishonorableState : State
{
    public override EGameState MyGameState => EGameState.Dishonored;

    public static event Action OnStartDishonorableCharge;
    public static event Action<bool> OnEndDishonorableCharge;

    [SerializeField] private AudioSource singleShotSource;
    [SerializeField] private AudioSource explosionSource;

    [SerializeField] private Button skipButton;
    private bool isWaiting;

    protected override void OnEnable()
    {
        base.OnEnable();

        skipButton.onClick.AddListener(SkipButtonPressed);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        skipButton.onClick.RemoveListener(SkipButtonPressed);
    }

    protected override void StartState()
    {
        StartCoroutine(DishonoredCoroutine());
    }
    protected override void FinalizedState() { }

    private void SkipButtonPressed() =>isWaiting = false;

    private IEnumerator DishonoredCoroutine()
    {
        isWaiting = true;
        
        singleShotSource.Play();
        
        TransitionManager.Instance.StartTransition(ETransition.Fade);
        TransitionManager.Instance.EndTransition(ETransition.Fade);

        yield return new WaitForSeconds(1f);

        TransitionManager.Instance.StartTransition(ETransition.Dishonorable);
        
        while (isWaiting) yield return null;

        isWaiting = false;

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