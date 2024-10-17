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
    float WaitTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if(dist < detectionDistance/3) {
            WaitTime += Time.deltaTime;
            if(WaitTime > 0.5f) {
                Attack();            
                WaitTime = 0f;
            }
        }
        else if(dist<detectionDistance) {
            Chase();
        } else {
            patrol();
        }
    }

    void patrol() {
        Vector3 dir = (waypoints[pointIndex].transform.position - transform.position).normalized;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, dir, out hit, 10f)) {
            dir = Vector3.Cross(dir, Vector3.up);
        }
        transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(dir.x,dir.z), 0f);
        vel.x = Mathf.MoveTowards(vel.x, dir.x*speed, 20f*Time.deltaTime);
        vel.z = Mathf.MoveTowards(vel.z, dir.z*speed, 20f*Time.deltaTime);

        if((waypoints[pointIndex].transform.position - transform.position).magnitude < 1.0f) {
            pointIndex = (pointIndex+1)%waypoints.Count;
        }
        GetComponent<Rigidbody>().velocity = vel;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Wall")) {
            pointIndex = (pointIndex+1)%waypoints.Count;
        }
    }

    void Chase() {
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
        Vector3 bulletVel = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * projectileSpeed;
        // Instantiate and shoot the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position + bulletVel*0.2f, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = bulletVel;

        // Optionally, implement a way to deal damage to the player when hit
        Destroy(projectile, 2f);

    }
}
