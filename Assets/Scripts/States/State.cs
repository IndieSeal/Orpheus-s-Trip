using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected bool isInState;
    
    protected virtual void OnEnable()
    {
        GameManager.OnGameStateChanged += OnStateChanged;
    }

    protected virtual void OnDisable()
    {
        GameManager.OnGameStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        if(state != GameState.Shoot)
        {
            isInState = false;
            End();
    
            return;
        }

        isInState = true;
        Start();
    }

    protected abstract void Start();
    protected abstract void End();
}