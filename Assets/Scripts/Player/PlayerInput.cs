using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputActionMap playerActionMap;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;

    private Vector2 moveDirection;
    public Vector2 MoveDirection { get => moveDirection; private set => moveDirection = value; }

    private bool jumpWasPressed;
    public bool JumpWasPressed { get => jumpWasPressed; private set => jumpWasPressed = value; }

    private bool shootWasPressed;
    public bool ShootWasPressed { get => shootWasPressed; private set => shootWasPressed = value; }


    private void OnEnable()
    {
        playerActionMap = InputActions.FindActionMap("Player");
        playerActionMap.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.Disable();
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    private void Update()
    {
        MoveDirection = moveAction.ReadValue<Vector2>();
        JumpWasPressed = jumpAction.WasPressedThisFrame();
        ShootWasPressed = shootAction.WasPressedThisFrame();
    }
}
