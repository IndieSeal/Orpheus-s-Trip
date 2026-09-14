using System;
using UnityEngine;
using UnityEngine.InputSystem;

using static UnityEngine.InputSystem.InputAction;

public class UserInput : MonoBehaviour
{
    public const string PRESS_ACTION_NAME = "Shoot";
    
    public static event Action ShootPressed;
    public static event Action ShootHeld;
    public static event Action ShootStopped;
    private InputAction shootAction;

    [SerializeField] private PlayerInput playerInput;

    void Awake()
    {
        shootAction = playerInput.actions.FindAction(PRESS_ACTION_NAME);
    }

    void OnEnable()
    {
        shootAction.started += OnPressActionStarted;
        shootAction.performed += OnHoldActionStarted;
        shootAction.canceled += OnStoppedActionStarted;
    }

    void OnDisable()
    {
        shootAction.started -= OnPressActionStarted;
        shootAction.performed -= OnHoldActionStarted;
        shootAction.canceled -= OnStoppedActionStarted;
    }

    private void OnPressActionStarted(CallbackContext cbct) => ShootPressed?.Invoke();
    private void OnHoldActionStarted(CallbackContext cbct) => ShootHeld?.Invoke();
    private void OnStoppedActionStarted(CallbackContext cbct) => ShootStopped?.Invoke();
}