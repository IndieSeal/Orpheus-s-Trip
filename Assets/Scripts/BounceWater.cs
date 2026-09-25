using UnityEngine;

public class BounceWater : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float height = 1.3f;
    private float deltaTime;
    private float initialRandomness;

    private float baseHeight;

    void Start()
    {
        baseHeight = transform.position.y;

        initialRandomness = Random.Range(0.6f, 1.4f);
    }

    void Update()
    {
        deltaTime += Time.deltaTime * speed * initialRandomness;

        float value = Mathf.InverseLerp(-1, 1, Mathf.Cos(deltaTime)) * height;
        transform.position = new Vector3(transform.position.x, baseHeight + value, transform.position.z);
    }
}