using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;
    public string funnyTag = "Player";

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hi");
        if (collision.collider.CompareTag(funnyTag))
        {
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        Destroy(gameObject); // Destroy the projectile after hitting the player
    }
}
