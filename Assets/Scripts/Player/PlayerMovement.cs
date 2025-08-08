using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpForce;

    private bool isTouchingGround;
    public bool IsTouchingGround { get => isTouchingGround; private set => isTouchingGround = value; }

    private bool isFlying;
    public bool IsFlying { get => isFlying; private set => isFlying = value; }


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (IsTouchingGround)
        {
            playerRigidbody.AddForceAtPosition(new Vector2(0, jumpForce), Vector2.up, ForceMode2D.Impulse);
            IsTouchingGround = false;
            IsFlying = true;
        }
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");
    }

    public void Move(Vector2 input)
    {
        playerRigidbody.linearVelocity = new Vector2(input.x * movementSpeed, playerRigidbody.linearVelocityY);
    }
    public void Move()
    {
        playerRigidbody.linearVelocityX = movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            print("Caiu no chão");
            IsTouchingGround = true;
            IsFlying = false;
        }
    }

}
