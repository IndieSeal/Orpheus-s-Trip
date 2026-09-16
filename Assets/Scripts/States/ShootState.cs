using System;
using UnityEngine;

public class ShootState : State
{
    public override EGameState MyGameState => EGameState.Shoot;
    
    public static Action<float> OnShoot;
    
    private float passedTime;

    protected override void StartState()
    {
        Debug.Log("SHOOT!");
        
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
    }

    private void Shoot()
    {
        Debug.Log($"BANG! Your reaction time: {passedTime}");

        OnShoot?.Invoke(passedTime);
        GameManager.Instance.GameState = EGameState.End;
    }
}