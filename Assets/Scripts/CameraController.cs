using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetAmount;
    public float smoothSpeed = 0.3f;

    void LateUpdate()
    {
        Vector3 offset = new Vector3(offsetAmount*-Mathf.Sin(target.localEulerAngles.y*Mathf.Deg2Rad)*0.15f,2f,-offsetAmount);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
