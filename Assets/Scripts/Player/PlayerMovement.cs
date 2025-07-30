using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpForce;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        playerRigidbody.AddForceAtPosition(new Vector2(0, jumpForce), Vector2.up, ForceMode2D.Impulse);
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");
    }

    public void Move(Vector2 input)
    {
        playerRigidbody.linearVelocity = new Vector2(input.x * movementSpeed, playerRigidbody.linearVelocityY);
    }
}
