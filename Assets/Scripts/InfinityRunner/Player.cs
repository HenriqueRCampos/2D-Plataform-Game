using UnityEngine;

namespace InfinityRunner
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed;

        [SerializeField]
        private float jumpForce;

        private Rigidbody2D playerRigidbody;
        private PlayerInput playerInput;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(playerInput.JumpWasPressed)
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            playerRigidbody.linearVelocityX = movementSpeed;
        }

        private void Jump()
        {
            playerRigidbody.AddForceAtPosition(new Vector2(0, jumpForce), Vector2.up, ForceMode2D.Impulse);
        }
    }
}
