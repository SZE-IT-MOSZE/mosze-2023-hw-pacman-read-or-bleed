using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPotion : MonoBehaviour
{
    public int healthIncreaseAmount = 10; // Amount of health to increase.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Find the player character by tag (assumes it's tagged as "Player")
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                HealthController playerHealth = player.GetComponent<HealthController>();

                if (playerHealth != null)
                {
                    playerHealth.AddHealth(healthIncreaseAmount); // Increase player's health by the specified amount.
                }
            }

            Destroy(gameObject); // Destroy the health potion after use.

            // Find the objects with the "Message" tag
            GameObject[] messageObjects = GameObject.FindGameObjectsWithTag("Message");

            foreach (var messageObject in messageObjects)
            {
                TextMeshProUGUI textToUpdate = messageObject.GetComponent<TextMeshProUGUI>();
                if (textToUpdate != null)
                {
                    textToUpdate.text = "Health Potion Acquired (+" + healthIncreaseAmount + " health)";
                }

                Animator animator = messageObject.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("Isfade");
                }
            }
        }
    }
}
