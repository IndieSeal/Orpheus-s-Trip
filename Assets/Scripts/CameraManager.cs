using System.Collections;
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
    public void SetCameraHandle() => CameraManager.Instance.SetHandler(this);
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

    public void InitiateShotsFired()
    {
        foreach(Camera cam in FindObjectsByType<Camera>(FindObjectsSortMode.None))
            StartCoroutine(ShotsFiredCoroutine(cam == this.cam ? transform.parent : cam.transform));
    }

    public IEnumerator ShotsFiredCoroutine(Transform customTransform = null)
    {
        StartCoroutine(Shake(0.2f, 1, true, customTransform));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Shake(0.2f, 1, true, customTransform));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Shake(0.2f, 1, true, customTransform));
    }

    public IEnumerator Shake(float duration, float magnitude, bool multiplyByLength, Transform transform = null)
    {
        if(transform == null) transform = this.transform;
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float multiplier = Mathf.InverseLerp(duration, 0, elapsed);
            if(!multiplyByLength) multiplier = 1;
            
            float x = Random.Range(-1f, 1f) * magnitude * multiplier;
            float y = Random.Range(-1f, 1f) * magnitude * multiplier;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}