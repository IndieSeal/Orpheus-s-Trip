using System;
using UnityEngine;

public enum EGameState
{
    Presentation,
    Hold,
    Shoot,
    EndDumb,
    Won,
    Lost,
}

public class GameManager : Singleton<GameManager>
{
    public static event Action<EGameState> OnGameStateChanged;
    public static event Action<bool> OnDecisionMade;
    
    public EGameState GameState
    {
        get => gameState;
        set {
            gameState = value;
            OnGameStateChanged?.Invoke(gameState);
        }
    }
    private EGameState gameState = EGameState.Presentation;

    void OnEnable()
    {
        ShootState.OnShoot += OnShoot;
    }

    void OnDisable()
    {
        ShootState.OnShoot -= OnShoot;
    }

    private void Start()
    {
        GameState = GameState;
    }

    private void OnShoot(float passedTime)
    {
        // There's definitely better ways to do this, but I can't think of anything rn :[
        bool playerWon = passedTime <= EnemyBoatHandler.Instance.ShootTime;
        GameState = playerWon ? EGameState.Won : EGameState.Lost;
        OnDecisionMade?.Invoke(playerWon);
    }
}