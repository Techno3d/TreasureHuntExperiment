using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpHeight = 1.0f;
    public float gravity = 9.81f;
    public float turnSmoothTime = 0.1f;

    private CharacterController controller;
    private Vector3 velocity;
    private float turnSmoothVelocity;
    float rotY = 0;
    public bool funny = false;
    [SerializeField]
    float rotationSpeed = 5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float xaxis = Input.GetAxis("Horizontal");
        float zaxis = Input.GetAxis("Vertical");
        float mousex = Input.GetAxis("Mouse X");
        rotY += mousex*rotationSpeed*Mathf.Deg2Rad*Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotY*Mathf.Rad2Deg, transform.rotation.z);

        // I love matrix multiplication
        Vector3 direction = new Vector3(
            zaxis*Mathf.Cos(rotY)-xaxis*Mathf.Sin(rotY),
            0f,
            -zaxis*Mathf.Sin(rotY)-xaxis*Mathf.Cos(rotY)
        );

        direction = Vector3.ClampMagnitude(direction, 1f);
        velocity.x = Mathf.MoveTowards(velocity.x, direction.x*5f, 30f*Time.deltaTime);
        velocity.z = Mathf.MoveTowards(velocity.z, direction.z*5f, 30f*Time.deltaTime);

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump")) {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if(Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKey(KeyCode.Return)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void onCollisionEnter() {
        velocity.x = 0;
        velocity.z = 0;
    }

    void AimMode() {
        // Movement input
        float xaxis = Input.GetAxis("Horizontal");
        float zaxis = Input.GetAxis("Vertical");
        float mousex = Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 1000, transform.rotation.z);
        Debug.Log(mousex);

        Vector3 direction = new Vector3(xaxis*10, 0f, zaxis);

        direction = Vector3.ClampMagnitude(direction, 1f);
        velocity.x = Mathf.MoveTowards(velocity.x, direction.x*5f, 30f*Time.deltaTime);
        velocity.z = Mathf.MoveTowards(velocity.z, direction.z*5f, 30f*Time.deltaTime);

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump")) {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
