using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetAmount;
    public float smoothSpeed = 0.2f;
    float upDist = 3f;

    void LateUpdate()
    {
        float up = Input.GetAxis("Mouse Y");
        upDist= Mathf.Clamp(up+upDist, -0.5f, 8f);
        Vector3 offset = new Vector3(-offsetAmount*Mathf.Cos(target.eulerAngles.y),upDist,offsetAmount*Mathf.Sin(target.eulerAngles.y));
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
