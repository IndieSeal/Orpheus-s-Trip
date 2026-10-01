using UnityEngine;

public class EnemyBoatHandler : BoatHandler
{
    public static EnemyBoatHandler Instance { get; protected set; }
    
    public override bool IsPlayer { get; } = false;

    [SerializeField] protected float shootTime = 1f;
    public float ShootTime => shootTime;

    void Awake()
    {
        Instance = this;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        DishonorableState.OnEndDishonorableCharge += SetSurpriseAngle;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        DishonorableState.OnEndDishonorableCharge -= SetSurpriseAngle;
    }

    protected override void OnSinkDishonorably()
    {
        
    }
}