using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAimer : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float upAxis = Input.GetAxis("Mouse Y");
        float horizontalAxis = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(-upAxis*6f, horizontalAxis*6f, 0f));
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Hi");
            Vector3 point = new(cam.pixelWidth/2f, cam.pixelHeight/2f, 0f);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
