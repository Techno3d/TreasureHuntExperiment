using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    List<Transform> waypoints;
    int pointIndex = 0;
    float speed = 2f;
    Vector2 vel = Vector2.zero;
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
        vel.x = Mathf.MoveTowards(vel.x, dir.x*speed, 20f*Time.deltaTime);
        if(Vector2.Distance(waypoints[pointIndex].transform.position, transform.position) < 0.5f) {
            pointIndex = (pointIndex+1)%waypoints.Count;
        }
    }
}
