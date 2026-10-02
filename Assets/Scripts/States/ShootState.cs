using System;
using TMPro;
using UnityEngine;

public class ShootState : State
{
    public override EGameState MyGameState => EGameState.Shoot;
    
    public static Action<float> OnShoot;
    
    [SerializeField] private TMP_Text win_passedTimeTxt;
    [SerializeField] private TMP_Text lose_passedTimeTxt;
    private float passedTime;

    [SerializeField] private AudioSource shootImpactSound;
    [SerializeField] private AudioSource weoweoSound;

    protected override void OnEnable()
    {
        base.OnEnable();

        HoldState.OnDishonored += SetEnemiesReaction;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        HoldState.OnDishonored -= SetEnemiesReaction;
    }

    protected override void StartState()
    {
        TransitionManager.Instance.StartTransition(ETransition.Shoot);
        TransitionManager.Instance.EndTransition(ETransition.Shoot);
        shootImpactSound.Play();
        
        passedTime = 0;
        UserInput.ShootPressed += Shoot;
    }
    
    protected override void FinalizedState()
    {
        UserInput.ShootPressed -= Shoot;
    }

    void Update()
    {
        if(!isInState) return;

        passedTime += Time.deltaTime;

        // There's probably a better way to do this, but can't think rn D:
        if(passedTime > EnemyBoatHandler.Instance.ShootTime) Shoot();
    }

    private void Shoot()
    {
        weoweoSound.Play();

        SetEnemiesReaction();
        win_passedTimeTxt.text = $"Your reaction time: {Math.Round(passedTime, 2)}s";
    
        OnShoot?.Invoke(passedTime);
    }

    private void SetEnemiesReaction()
    {
        lose_passedTimeTxt.text = $"Enemie's reaction time: {EnemyBoatHandler.Instance.ShootTime}s";
    }
}