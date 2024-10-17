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
    [SerializeField]
    public GameObject projectilePrefab;
    [SerializeField]
    public float projectileSpeed = 10f;
    int pointIndex = 0;
    Vector3 vel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position)<detectionDistance) {
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

        Debug.Log(pointIndex + " : " + waypoints[pointIndex].transform.position + " " + transform.position);
        if(Vector2.Distance(waypoints[pointIndex].transform.position, transform.position) < 1.0f) {
            pointIndex = (pointIndex+1)%waypoints.Count;
            Debug.Log(pointIndex);
        }
        GetComponent<Rigidbody>().velocity = vel;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Wall")) {
            pointIndex = (pointIndex+1)%waypoints.Count;
            Debug.Log(pointIndex);
        }
    }

    void chase() {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 dir = new Vector3(
            playerPos.x - transform.position.x,
            transform.position.y+1,
            playerPos.z - transform.position.z 
        );
        dir.Normalize();
        transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(dir.x,dir.z), 0f);
        vel.x = Mathf.MoveTowards(vel.x, dir.x*speed, 20f*Time.deltaTime);
        vel.z = Mathf.MoveTowards(vel.z, dir.z*speed, 20f*Time.deltaTime);
        GetComponent<Rigidbody>().velocity = vel;
    }

    void Attack() {
            // Instantiate and shoot the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * projectileSpeed;

        // Optionally, implement a way to deal damage to the player when hit
        Destroy(projectile, 2f);

    }
}
