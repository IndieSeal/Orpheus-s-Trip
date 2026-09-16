using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract EGameState MyGameState { get; }
    protected bool isInState;
    
    protected virtual void OnEnable()
    {
        GameManager.OnGameStateChanged += OnStateChanged;
    }

    protected virtual void OnDisable()
    {
        GameManager.OnGameStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(EGameState state)
    {
        if(isInState)
        {
            if(state == MyGameState) return;

            isInState = false;
            FinalizedState();
    
            return;
        }
        else if(state == MyGameState)
        {
            isInState = true;
            StartState();
        }
    }

    protected abstract void StartState();
    protected abstract void FinalizedState();
}