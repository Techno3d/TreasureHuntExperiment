using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetAmount;
    public float smoothSpeed = 0.3f;

    void LateUpdate()
    {
        float xaxis = Input.GetAxis("Horizontal");
        float zaxis = Input.GetAxis("Vertical");
        Vector3 offset = new Vector3(offsetAmount*xaxis*0.1f,2f,-offsetAmount);
        //offset.x *= Mathf.Sign(offset.z);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
