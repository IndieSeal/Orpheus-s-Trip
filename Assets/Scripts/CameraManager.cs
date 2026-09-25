using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class CameraHandle
{
    public bool initialInstantTransition = true;
    
    public float lerpSpeed = 1;
    
    public Transform target;
    public Transform lookFrom;
    public float targetFOV = 30;

    [Button]
    private void SetCameraHandle()
    {
        CameraManager.Instance.SetHandler(this);
    }
}

[RequireComponent(typeof(Camera))]
public class CameraManager : Singleton<CameraManager>
{
    public CameraHandle CameraHandler { get; private set; }
    private Camera cam;

    protected override void Awake()
    {
        base.Awake();
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(CameraHandler == null) return;
        
        transform.position = Vector3.Lerp(transform.position, CameraHandler.lookFrom.position, CameraHandler.lerpSpeed * Time.deltaTime);
        transform.LookAt(CameraHandler.target);

        cam.fieldOfView = CameraHandler.targetFOV;
    }

    public void SetHandler(CameraHandle handler)
    {
        CameraHandler = handler;
        if(handler.initialInstantTransition) transform.position = handler.lookFrom.position;
    }
}