using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAimer : MonoBehaviour
{
    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 point = new(camera.pixelWidth/2f, camera.pixelHeight/2f, 0f);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }
}
