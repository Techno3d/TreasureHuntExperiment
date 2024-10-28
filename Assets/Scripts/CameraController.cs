using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetAmount;
    public float smoothSpeed = 0.2f;
    float upDist = 3f;

    void LateUpdate()
    {
        float divDist = 1f;
        if(Input.GetMouseButton(0)) {
            divDist = 3f;
        }

        float up = Input.GetAxis("Mouse Y") / (Input.GetMouseButton(0)?2.5f:1);
        upDist= Mathf.Clamp(up+upDist, -0.5f, 8f);
        Vector3 offset = new Vector3(
            -(offsetAmount)*Mathf.Cos(target.eulerAngles.y*Mathf.Deg2Rad)/divDist,
            upDist/divDist,
            (offsetAmount)*Mathf.Sin(target.eulerAngles.y*Mathf.Deg2Rad)/divDist
        );
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target);
        
        // Offset
        // float shoulderDist = Input.GetMouseButton(0)?1.5f:0;
        // offset.x += shoulderDist*Mathf.Sin(target.eulerAngles.y*Mathf.Deg2Rad);
        // offset.y += shoulderDist;
        // offset.z += shoulderDist*Mathf.Cos(target.eulerAngles.y*Mathf.Deg2Rad);
        // desiredPosition = target.position + offset;
        // smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;
        
        // Fps
        // offset.x *= Input.GetMouseButton(0)?-1f:1;
        // offset.z *= Input.GetMouseButton(0)?-1f:1;
        // desiredPosition = target.position + offset;
        // smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;
    }
}
