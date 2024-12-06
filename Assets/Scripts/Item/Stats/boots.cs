using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boots : MonoBehaviour
{
    public float speedIncreaseAmount = 50f; // Amount of speed to increase.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the player character by tag (assumes it's tagged as "Player")
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

                if (playerMovement != null)
                {
                    playerMovement.moveSpeed += speedIncreaseAmount;
                }

                // Destroy the boots item after use.
                Destroy(gameObject);

                // Find the objects with the "Message" tag
                GameObject[] messageObjects = GameObject.FindGameObjectsWithTag("Message");

                foreach (var messageObject in messageObjects)
                {
                    TextMeshProUGUI textToUpdate = messageObject.GetComponent<TextMeshProUGUI>();
                    if (textToUpdate != null)
                    {
                        textToUpdate.text = "Boots Acquired (+" + speedIncreaseAmount + " Speed)";
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
