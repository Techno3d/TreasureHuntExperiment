using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            // if (playerHealth != null)
            // {
            //     playerHealth.TakeDamage(damage);
            // }
            Destroy(gameObject); // Destroy the projectile after hitting the player
        }
    }
}
