using UnityEngine;

public class PositionConstraint : MonoBehaviour
{
    [SerializeField] private Transform constraint;
    private Vector3 spawnOffset;

    void Awake()
    {
        spawnOffset = transform.position - constraint.position;
    }

    void Update()
    {
        transform.position = constraint.position + spawnOffset;
    }
}