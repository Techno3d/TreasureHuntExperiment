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
    public bool funny = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement input
        float vertical = Input.GetAxis("Horizontal");
        float horizontal = Mathf.Clamp(Input.GetAxis("Vertical"), -0.2f, 0.5f);
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y+vertical*Time.deltaTime*7f, 0f);
        Vector3 direction = new Vector3(horizontal*Mathf.Cos(transform.rotation.eulerAngles.y), 0f, -horizontal*Mathf.Sin(transform.rotation.eulerAngles.y));
        direction *= speed;
        velocity.x = Mathf.MoveTowards(velocity.x, direction.x, 40f*Time.deltaTime);
        velocity.z = Mathf.MoveTowards(velocity.z, direction.z, 40f*Time.deltaTime);

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        //Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void onCollisionEnter() {
        velocity.x = 0;
        velocity.z = 0;
    }

    void AimMode() {
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
