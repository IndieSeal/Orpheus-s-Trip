using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnTime = 5;
    [SerializeField] private float maxSpawnTime = 5;
    private float timer;

    [Space]
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    [Space]
    [SerializeField] private GameObject prefab;

    void Awake()
    {
        timer = GetRandomTime();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = GetRandomTime();
            Instantiate(prefab, Utilities.GetRandomPoint(startPosition.position, endPosition.position), Quaternion.identity);
        }
    }

    private float GetRandomTime()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }
}