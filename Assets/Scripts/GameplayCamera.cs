using UnityEngine;

public class GameplayCamera : MonoBehaviour
{
    private Transform playerTransform;
    private readonly float verticalPosition = 0f;

    [SerializeField] private float trackingSpeed;
    [SerializeField] private float offset;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 cameraDestinationPosition = new Vector3(playerTransform.position.x + offset, verticalPosition, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, cameraDestinationPosition, trackingSpeed * Time.deltaTime);
    }
}
