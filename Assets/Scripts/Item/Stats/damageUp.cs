using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageUp : MonoBehaviour
{
    public int damageIncreaseAmount = 10; // Amount of damage to increase.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the player character by tag (assumes it's tagged as "Player")
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                PlayerDamageController playerDamageController = player.GetComponent<PlayerDamageController>();

                if (playerDamageController != null)
                {
                    playerDamageController.IncreaseDamage(damageIncreaseAmount);
                }

                // Destroy the item after use.
                Destroy(gameObject);

                // Find objects with the "Message" tag
                GameObject[] messageObjects = GameObject.FindGameObjectsWithTag("Message");

                foreach (var messageObject in messageObjects)
                {
                    TextMeshProUGUI textToUpdate = messageObject.GetComponent<TextMeshProUGUI>();
                    if (textToUpdate != null)
                    {
                        textToUpdate.text = "Damage Up (+" + damageIncreaseAmount + " Damage)";
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
}
