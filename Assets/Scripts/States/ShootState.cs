using System;
using UnityEngine;

public class ShootState : State
{
    public override EGameState MyGameState => EGameState.Shoot;
    
    public static Action<float> OnShoot;
    
    private float passedTime;

    [SerializeField] private AudioSource shootImpactSound;
    [SerializeField] private AudioSource weoweoSound;

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
        Debug.Log($"BANG! Your reaction time: {passedTime}");

        weoweoSound.Play();

        OnShoot?.Invoke(passedTime);
    }
}