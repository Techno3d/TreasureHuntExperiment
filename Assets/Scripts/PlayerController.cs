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

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement input
        float xaxis = Input.GetAxis("Horizontal");
        float zaxis = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xaxis, 0f, zaxis);
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
