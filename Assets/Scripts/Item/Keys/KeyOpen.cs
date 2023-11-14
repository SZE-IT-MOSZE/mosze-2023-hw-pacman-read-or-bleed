using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyItem : MonoBehaviour
{
    private GameObject door; // Reference to the door that the key unlocks.
    private GameObject keyDisplayObject; // Reference to the GameObject with the UI Image.

    private void Start()
    {
        // Find the key display object at the start.
        keyDisplayObject = GameObject.FindGameObjectWithTag("KeyUI");

        // Disable the key display object if found.
        if (keyDisplayObject != null)
        {
            keyDisplayObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the player character by tag (assumes it's tagged as "Player")
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                // Unlock the door if it exists.
                // ...

                // Destroy the key item after use.
                Destroy(gameObject);

                // Display the key's sprite on the UI.
                if (keyDisplayObject != null)
                {
                    Image keyDisplayImage = keyDisplayObject.GetComponent<Image>();

                    if (keyDisplayImage != null)
                    {
                        SpriteRenderer keySpriteRenderer = GetComponent<SpriteRenderer>();

                        if (keySpriteRenderer != null)
                        {
                            keyDisplayImage.sprite = keySpriteRenderer.sprite;
                            keyDisplayObject.SetActive(true); // Show the UI Image.
                        }
                    }
                }

                // Find objects with the "Message" tag
                GameObject[] messageObjects = GameObject.FindGameObjectsWithTag("Message");

                foreach (var messageObject in messageObjects)
                {
                    TextMeshProUGUI textToUpdate = messageObject.GetComponent<TextMeshProUGUI>();
                    if (textToUpdate != null)
                    {
                        textToUpdate.text = "Key Obtained!";
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
