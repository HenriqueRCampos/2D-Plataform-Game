using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbodyPhysic;

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
        rigidbodyPhysic = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        rigidbodyPhysic.AddForceAtPosition(new Vector2(0, jumpForce), Vector2.up, ForceMode2D.Impulse);
        isTouchingGround = false;
        isFlying = true;
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");
    }

    public void Move(Vector2 input)
    {
        rigidbodyPhysic.linearVelocity = new Vector2(input.x * movementSpeed, rigidbodyPhysic.linearVelocityY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            IsTouchingGround = true;
            IsFlying = false;
        }
    }

}
