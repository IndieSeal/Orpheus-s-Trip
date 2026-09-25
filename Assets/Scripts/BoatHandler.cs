using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    [SerializeField] private CameraHandle cameraHandler;
    public CameraHandle Handler => cameraHandler;

    [SerializeField] private float moveSpeed = 5;

    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;    
    }
}