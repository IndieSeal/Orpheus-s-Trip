using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    [SerializeField] private CameraHandle cameraHandler;
    public CameraHandle Handler => cameraHandler;
}