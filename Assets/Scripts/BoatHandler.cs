using System.Collections;
using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    public virtual bool IsPlayer { get; } = true;

    [SerializeField] protected CameraAngle surpriseAngle;
    public CameraAngle SurpriseAngle => surpriseAngle;

    protected void OnEnable()
    {
        GameManager.OnDecisionMade += OnShot;
        HoldState.OnDishonored += OnDishonorable;
    }

    protected void OnDisable()
    {
        GameManager.OnDecisionMade -= OnShot;
        HoldState.OnDishonored -= OnDishonorable;
    }

    private void OnDishonorable()
    {
        StartCoroutine(OnDishonorableCoroutine());
    }

    protected virtual void OnShot(bool playerWon)
    {
        if(playerWon != IsPlayer) return;

        StartCoroutine(OnShotCoroutine());
    }

    protected IEnumerator OnShotCoroutine()
    {
        yield return null;
        surpriseAngle.CameraHandler.SetCameraHandle();
    }

    protected IEnumerator OnDishonorableCoroutine()
    {
        yield return null;
        Debug.Log("You whiffed");
    }
}