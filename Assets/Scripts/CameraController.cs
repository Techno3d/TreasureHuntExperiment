using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetAmount;
    public float smoothSpeed = 0.2f;

    void LateUpdate()
    {
        Vector3 offset = new Vector3(-offsetAmount*Mathf.Cos(target.eulerAngles.y),3f,offsetAmount*Mathf.Sin(target.eulerAngles.y));
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
