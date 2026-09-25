using Sirenix.OdinInspector;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    [SerializeField] private CameraHandle cameraHandler;

    [SerializeField] private bool setAtStart = true;

    void Start()
    {
        if(setAtStart) CameraManager.Instance.SetHandler(cameraHandler);
    }
}