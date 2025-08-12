using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    public PlayerMovementType PlayerMovementType;

    public Vector2 colliderLeftOffset = new Vector2();
    public Vector2 colliderRightOffset = new Vector2();

    private PlayerMovement playerMovement;
    private PlayerInput playerInput;
    private PlayerAnimator playerAnimator;
    private CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (playerInput.JumpWasPressed)
        {
            playerMovement.Jump();
            playerAnimator.TriggerJumpAnimation();
        }

        if (playerInput.ShootWasPressed)
        {
            playerMovement.Shoot();
        }

        if (playerInput.MoveDirection.sqrMagnitude > 0 && playerMovement.IsTouchingGround)
        {
            playerAnimator.SetWalkingAnimation(true);
            playerAnimator.FlipSpriteXAxis(playerInput.IsMoveingLeft);
            ApplyColliderOffset();
        }
        else if (playerInput.MoveDirection.sqrMagnitude == 0 || !playerMovement.IsTouchingGround)
        {
            playerAnimator.SetWalkingAnimation(false);
        }

        playerAnimator.SetFlyingAnimation(playerMovement.IsFlying);
    }

    private void FixedUpdate()
    {
        ExecuteMovementType();
    }

    private void ExecuteMovementType()
    {
        switch (PlayerMovementType)
        {
            case PlayerMovementType.ControlledHorizontalLinearVelocity:
                playerMovement.Move(playerInput.MoveDirection);
                break;

            case PlayerMovementType.ConstantHorizontalLinearVelocity:
                playerMovement.Move();
                break;
        }
    }

    private void ApplyColliderOffset()
    {
        if (playerInput.IsMoveingLeft)
        {
            capsuleCollider.offset = colliderRightOffset;
        }
        else
        {
            capsuleCollider.offset = colliderLeftOffset;
        }
    }
}
