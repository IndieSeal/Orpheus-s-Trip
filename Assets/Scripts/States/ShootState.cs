using System;
using UnityEngine;

public class ShootState : State
{
    public override GameState MyGameState => GameState.Shoot;
    
    public static Action<float> OnShoot;
    
    private bool started = false;
    private float passedTime;

    protected override void Start()
    {
        passedTime = 0;
        started = true;
        
        UserInput.ShootPressed += Shoot;
    }
    
    protected override void End()
    {
        UserInput.ShootPressed -= Shoot;
    }

    void Update()
    {
        if(!started) return;

        passedTime += Time.deltaTime;
    }

    private void Shoot()
    {
        started = false;

        OnShoot?.Invoke(passedTime);
        GameManager.Instance.GameState = GameState.End;
    }
}