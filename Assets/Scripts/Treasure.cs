using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    void Update() {
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.time)+1)/2f, transform.position.z);
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
