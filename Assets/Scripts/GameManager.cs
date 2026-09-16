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
    
    public EGameState GameState
    {
        get => gameState;
        set {
            gameState = value;
            OnGameStateChanged?.Invoke(gameState);
        }
    }
    private EGameState gameState = EGameState.Presentation;

    private void Start()
    {
        GameState = GameState;
    }
}