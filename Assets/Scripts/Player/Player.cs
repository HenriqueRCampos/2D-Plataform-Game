using UnityEngine;

[RequireComponent (typeof(PlayerInput))]
[RequireComponent (typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.JumpWasPressed)
        {
            playerMovement.Jump();
        }

        if(playerInput.ShootWasPressed)
        {
            playerMovement.Shoot();
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move(playerInput.MoveDirection);
    }
}
