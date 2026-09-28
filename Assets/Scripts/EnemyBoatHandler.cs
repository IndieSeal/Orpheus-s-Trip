using UnityEngine;

public class EnemyBoatHandler : BoatHandler
{
    public static EnemyBoatHandler Instance { get; protected set; }
    
    [SerializeField] protected float shootTime = 1f;
    public float ShootTime => shootTime;

    void Awake()
    {
        Instance = this;
    }
}