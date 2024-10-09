using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("ScoreCounter").GetComponent<ScoreTracker>().IncScore(1);
            Destroy(gameObject); 
        }
    }
}
