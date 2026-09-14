using System;
using UnityEngine;

public enum GameState
{
    Presentation,
    Hold,
    Shoot,
    End,
}

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnGameStateChanged;
    
    public GameState GameState
    {
        get => gameState;
        set {
            gameState = value;
            OnGameStateChanged?.Invoke(gameState);
        }
    }
    private GameState gameState;


}