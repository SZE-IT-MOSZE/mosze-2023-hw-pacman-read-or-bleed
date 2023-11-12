using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lampPicku : MonoBehaviour
{
    public float radiusIncreaseAmount = 50f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Rendering.Universal.Light2D spotlight = other.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();

            if (spotlight != null)
            {
                spotlight.pointLightOuterRadius += radiusIncreaseAmount;

                Destroy(gameObject); // Destroy the health potion after use.
                
                // Find objects with the "Message" tag
                GameObject[] messageObjects = GameObject.FindGameObjectsWithTag("Message");

                foreach (var messageObject in messageObjects)
                {
                    TextMeshProUGUI textToUpdate = messageObject.GetComponent<TextMeshProUGUI>();
                    if (textToUpdate != null)
                    {
                        textToUpdate.text = "Lamp Acquired (+" + radiusIncreaseAmount + " Vision)";
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
