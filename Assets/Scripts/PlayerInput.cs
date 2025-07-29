using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    public InputActionAsset InputActions;

    public float moveSpeed;
    public float jumpSpeed;

    private InputActionMap playerActionMap;
    private Rigidbody2D playerRigidbody;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;

    private Vector2 moveActionValue;

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

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveActionValue = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
        }

        if (shootAction.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Moveing();
    }

    private void Jump()
    {
        playerRigidbody.AddForceAtPosition(new Vector2(0, jumpSpeed), Vector2.up, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Debug.Log("Shooting!");
    }

    private void Moveing()
    {
        playerRigidbody.linearVelocity = new Vector2(moveActionValue.x * moveSpeed, playerRigidbody.linearVelocityY);
    }
}
