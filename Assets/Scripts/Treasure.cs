using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public float initialHeight = 0.5f;
    void Start() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)) {
            initialHeight = 0.5f+hit.point.y;
        } else {
            Destroy(gameObject);
        }
    }
    void Update() {
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.time)+1)/2f+initialHeight, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("ScoreCounter").GetComponent<ScoreTracker>().IncScore(1);
            Destroy(gameObject); 
        }
    }
}
