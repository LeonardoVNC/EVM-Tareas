using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    private Vector2 movementInput;
    private Rigidbody rb;
    private Animator animator;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private bool wasMoving = false;

    private ObstacleManager obsManager;
    public AudioClip coinSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        animator = GetComponentInChildren<Animator>();
        
        obsManager = Object.FindFirstObjectByType<ObstacleManager>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update() {
        Vector3 moveDir = new Vector3(movementInput.x, 0, movementInput.y);
        if (moveDir.magnitude > 0.1f) {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 15f);
        }

        if (animator != null) {
            bool isMovingNow = moveDir.magnitude > 0.1f;

            if (isMovingNow && !wasMoving) {
                animator.SetTrigger("run");
            }
            else if (!isMovingNow && wasMoving) {
                animator.SetTrigger("idle");
            }

            wasMoving = isMovingNow;
        }
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
            if (animator != null) animator.SetTrigger("jump");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Moneda"))
        {
            GameManager.instance.AddScore();
            obsManager.GenerateLevel(Random.Range(0, 8), Random.Range(0, 8));
            audioSource.PlayOneShot(coinSound);
        }
    }
}
