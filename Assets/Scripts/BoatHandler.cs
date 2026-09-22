using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    //Should be kept in a camera manager, but eh, works for now
    [SerializeField] private float lerpSpeed = 1;
    
    [SerializeField] private Transform target;
    [SerializeField] private Transform lookFrom;
    [SerializeField] private float targetFOV = 30;

    void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, lookFrom.position, lerpSpeed * Time.deltaTime);
        Camera.main.transform.LookAt(target);

        Camera.main.fieldOfView = targetFOV;
    }
}