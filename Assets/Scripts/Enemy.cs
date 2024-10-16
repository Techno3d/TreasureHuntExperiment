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
    float detectionDistance = 10f;
    int pointIndex = 0;
    Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position)<2f) {
            chase();
        } else {
            patrol();
        }
    }

    void patrol() {
        Vector3 dir = (waypoints[pointIndex].transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(dir.x,dir.z), 0f);
        vel.x = Mathf.MoveTowards(vel.x, dir.x*speed, 20f*Time.deltaTime);
        vel.z = Mathf.MoveTowards(vel.z, dir.z*speed, 20f*Time.deltaTime);

        if(Vector2.Distance(waypoints[pointIndex].transform.position, transform.position) < 0.5f) {
            pointIndex = (pointIndex+1)%waypoints.Count;
        }
        transform.position += vel*Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Wall")) {
            Debug.Log("hi");
            pointIndex = (pointIndex+1)%waypoints.Count;
            Debug.Log(pointIndex);
        }
    }

    void chase() {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = new Vector3(
            Mathf.MoveTowards(transform.position.x, playerPos.x, speed * Time.deltaTime),
            transform.position.y,
            Mathf.MoveTowards(transform.position.z, playerPos.z, speed * Time.deltaTime)
        );
    }
}
