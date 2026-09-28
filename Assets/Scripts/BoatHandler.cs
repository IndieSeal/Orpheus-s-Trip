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

    protected void OnEnable()
    {
        EndState.OnStartSink += OnSink;
        HoldState.OnDishonored += OnDishonorable;
    }

    protected void OnDisable()
    {
        EndState.OnStartSink -= OnSink;
        HoldState.OnDishonored -= OnDishonorable;
    }

    private void OnDishonorable()
    {
        // Nothing rn
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
}