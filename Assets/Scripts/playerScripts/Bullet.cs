using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Wall"))
    {
        // Destroy the bullet when it hits a wall
        Destroy(gameObject);
    }
    else if (collision.CompareTag("Enemy"))
    {
        // Reduce enemy's health by 10 when hit by the bullet
        HealthController enemyHealth = collision.GetComponent<HealthController>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(10);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
}
