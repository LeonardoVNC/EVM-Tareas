using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    private Vector2 movementInput;
    private Rigidbody rb;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private ObstacleManager obsManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        obsManager = Object.FindFirstObjectByType<ObstacleManager>();
    }

    void FixedUpdate() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Vector3 direction = new Vector3(movementInput.x, 0, movementInput.y);
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
    }

    public void OnMove(InputValue data) {
        movementInput = data.Get<Vector2>();
    }

    public void OnJump(InputValue data) {
        if (isGrounded) {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("AYY");
        if (other.CompareTag("Moneda"))
        {
            obsManager.GenerateLevel(Random.Range(0, 8), Random.Range(0, 8));
        }
    }
}
