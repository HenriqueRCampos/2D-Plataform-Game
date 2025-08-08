using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public PlayerMovementType PlayerMovementType;

    private PlayerMovement playerMovement;
    private PlayerInput playerInput;
    private PlayerAnimator playerAnimator;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<PlayerAnimator>();
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
}
