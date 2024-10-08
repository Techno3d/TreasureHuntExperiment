using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Update the score here (You might want to create a GameManager to manage score)
            Destroy(gameObject); // Remove the treasure
        }
    }

    void Update()
    {
        
    }
}
