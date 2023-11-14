using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            // Destroy the bullet when it hits a wall
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            // Find the player character by tag (assumes it's tagged as "Player")
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                // Get the PlayerDamageController script on the player
                PlayerDamageController playerDamageController = player.GetComponent<PlayerDamageController>();

                if (playerDamageController != null)
                {
                    // Get the player's damage amount from the PlayerDamageController
                    int playerDamageAmount = playerDamageController.GetPlayerDamage();
                  

                    // Deal the total damage to the enemy
                    HealthController enemyHealth = collision.GetComponent<HealthController>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(playerDamageAmount);
                      
                    }
                }
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
