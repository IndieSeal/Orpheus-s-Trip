using System;
using UnityEngine;

public class BounceWater : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float height = 1.3f;
    private float deltaTime;

    private float baseHeight;

    void Start()
    {
        baseHeight = transform.position.y;
    }

    void Update()
    {
        deltaTime += Time.deltaTime * speed;

        float value = Mathf.InverseLerp(-1, 1, Mathf.Cos(deltaTime)) * height;
        transform.position = new Vector3(transform.position.x, baseHeight + value, transform.position.z);
    }
}