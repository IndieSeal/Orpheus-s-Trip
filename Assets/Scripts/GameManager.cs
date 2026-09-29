using System;
using UnityEngine;

public enum EGameState
{
    Presentation,
    Hold,
    Shoot,
    End,
}

public class GameManager : Singleton<GameManager>
{
    public static event Action<EGameState> OnGameStateChanged;
    public static event Action<bool> OnDecisionMade;

    public static event Action OnSkipMade;
    
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
        UserInput.SkipPressed += OnSkip;
    }

    void OnDisable()
    {
        ShootState.OnShoot -= OnShoot;
        UserInput.SkipPressed -= OnSkip;
    }

    private void Start()
    {
        GameState = GameState;
    }

    private void OnShoot(float passedTime)
    {
        // There's definitely better ways to do this, but I can't think of anything rn :[
        bool playerWon = passedTime <= EnemyBoatHandler.Instance.ShootTime;
        GameState = EGameState.End;
        OnDecisionMade?.Invoke(playerWon);
    }

    private void OnSkip()
    {
        if(GameState != EGameState.Presentation) return;
        
        GameState = EGameState.Hold;
        OnSkipMade?.Invoke();
    }
}