using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    public int playerDamage = 10; // Initial player damage value

    // Function to increase player damage
    public void IncreaseDamage(int amount)
    {
        playerDamage += amount;
    }

    // Function to get the current player damage
    public int GetPlayerDamage()
    {
        return playerDamage;
    }

    // You can add more functions for damage control as needed

    // Example of how to deal damage to an enemy
    public void DealDamageToEnemy(HealthController enemyHealth, int damage)
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}
