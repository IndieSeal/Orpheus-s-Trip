using System;
using UnityEngine;

public class ShootState : MonoBehaviour
{
    public static Action<float> OnShoot;
    
    private bool started = false;
    private float passedTime;

    void OnEnable()
    {
        GameManager.OnGameStateChanged += OnStateChanged;
    }

    void OnDisable()
    {
        GameManager.OnGameStateChanged -= OnStateChanged;
    }

    void Update()
    {
        if(!started) return;

        passedTime += Time.deltaTime;
    }

    private void OnStateChanged(GameState state)
    {
        if(state != GameState.Shoot)
        {
            End();
            return;
        }

        Start();
    }

    private void Start()
    {
        passedTime = 0;
        started = true;
        
        UserInput.ShootPressed += Shoot;
    }

    private void Shoot()
    {
        started = false;

        OnShoot?.Invoke(passedTime);
        GameManager.Instance.GameState = GameState.End;
    }

    private void End()
    {
        UserInput.ShootPressed -= Shoot;
    }
}