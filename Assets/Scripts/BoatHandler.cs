using System.Collections;
using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    public virtual bool IsPlayer { get; } = true;

    [SerializeField] protected CameraAngle surpriseAngle;
    public CameraAngle SurpriseAngle => surpriseAngle;

    [SerializeField] private SpriteRenderer characterSprRenderer;
    [SerializeField] private Sprite characterDeadSprite;

    [SerializeField] private Animator animator;

    protected virtual void OnEnable()
    {
        EndState.OnStartSink += OnSink;
        EndState.OnStartWinner += SetSurpriseAngle;
        DishonorableState.OnStartDishonorableCharge += OnSinkDishonorably;
    }

    protected virtual void OnDisable()
    {
        EndState.OnStartSink -= OnSink;
        EndState.OnStartWinner -= SetSurpriseAngle;
        DishonorableState.OnStartDishonorableCharge -= OnSinkDishonorably;
    }

    protected virtual void OnSink(bool playerWon)
    {
        if(playerWon != IsPlayer)
        {
            characterSprRenderer.sprite = characterDeadSprite;
            animator.SetTrigger("Death");
            return;
        }

        // This boat won
    }

    protected virtual void OnSinkDishonorably()
    {
        animator.SetTrigger("Death");
    }

    protected void SetSurpriseAngle(bool playerWon)
    {
        if(playerWon != IsPlayer) return;

        SurpriseAngle.CameraHandler.SetCameraHandle();
    }
}