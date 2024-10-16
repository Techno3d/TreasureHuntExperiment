using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    List<Transform> waypoints;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float detectionDistance = 2f;
    int pointIndex = 0;
    Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (waypoints[pointIndex].transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(dir.z,dir.x), 0f);
        vel.x = Mathf.MoveTowards(vel.x, dir.x*speed, 20f*Time.deltaTime);
        vel.z = Mathf.MoveTowards(vel.z, dir.z*speed, 20f*Time.deltaTime);
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, forward, out hit, detectionDistance)){
            if (hit.collider.CompareTag("Wall")){
                SelectNewWaypoint();
//you can change this to make your agent do something else!
            }
        }

        SelectNewWaypoint();
        transform.position += vel*Time.deltaTime;
    }

    void SelectNewWaypoint() {
        if(Vector2.Distance(waypoints[pointIndex].transform.position, transform.position) < 0.5f) {
            pointIndex = (pointIndex+1)%waypoints.Count;
        }
    }
}
