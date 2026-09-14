using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"Duplicate singleton of type {typeof(T)} detected on {gameObject.name}, destroying.");
            Destroy(gameObject);
            return;
        }

        Instance = this as T;
    }
}