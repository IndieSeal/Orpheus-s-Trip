using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class HoldState : State
{
    public override EGameState MyGameState => EGameState.Hold;

    public static event System.Action OnDishonored;

    [SerializeField, MinMaxSlider(0f, 5f)] private Vector2 minMaxTime = new Vector2(0.3f, 2f);

    [SerializeField] private AudioSource drumsAudio;

    protected override void StartState()
    {
        UserInput.ShootPressed += Shoot;
        GameManager.OnGameStateChanged += TryDisableDrums;

        drumsAudio.Play();

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
        OnDishonored?.Invoke();
        GameManager.Instance.GameState = EGameState.EndDumb;
    }

    private void TryDisableDrums(EGameState state)
    {
        if(state == MyGameState || state == EGameState.Shoot) return;

        drumsAudio.Stop();
        GameManager.OnGameStateChanged -= TryDisableDrums;
    }
}