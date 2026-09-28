using System;
using UnityEngine;
using UnityEngine.InputSystem;

using static UnityEngine.InputSystem.InputAction;

public class UserInput : MonoBehaviour
{
    public const string SHOOT_ACTION_NAME = "Shoot";
    public const string SKIP_ACTION_NAME = "Skip";
    
    public static event Action SkipPressed;
    private InputAction skipAction;

    public static event Action ShootPressed;
    public static event Action ShootHeld;
    public static event Action ShootStopped;
    private InputAction shootAction;

    [SerializeField] private PlayerInput playerInput;

    void Awake()
    {
        shootAction = playerInput.actions.FindAction(SHOOT_ACTION_NAME);
        skipAction = playerInput.actions.FindAction(SKIP_ACTION_NAME);
    }

    void OnEnable()
    {
        skipAction.started += OnSkipStarted;
        
        shootAction.started += OnShootStarted;
        shootAction.performed += OnShootPerformed;
        shootAction.canceled += OnShootCanceled;
    }

    void OnDisable()
    {
        skipAction.started -= OnSkipStarted;

        shootAction.started -= OnShootStarted;
        shootAction.performed -= OnShootPerformed;
        shootAction.canceled -= OnShootCanceled;
    }

    private void OnSkipStarted(CallbackContext cbct) => SkipPressed?.Invoke();

    private void OnShootStarted(CallbackContext cbct) => ShootPressed?.Invoke();
    private void OnShootPerformed(CallbackContext cbct) => ShootHeld?.Invoke();
    private void OnShootCanceled(CallbackContext cbct) => ShootStopped?.Invoke();
}