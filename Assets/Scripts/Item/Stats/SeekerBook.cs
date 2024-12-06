using System.Collections;
using UnityEngine;


public class SeekerBook : MonoBehaviour
{
    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the object with the tag "GlobalLight"
            GameObject globalLightObject = GameObject.FindGameObjectWithTag("GlobalLight");

            if (globalLightObject != null)
            {
                // Get the Light2D components from the object
                UnityEngine.Rendering.Universal.Light2D playerLight = globalLightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();

                if (playerLight != null)
                {
                    StartCoroutine(ActivateSeekerBook(playerLight));
                }
                else
                {
                    Debug.LogError("Light2D component not found on the object with tag 'GlobalLight'.");
                }
            }
            else
            {
                Debug.LogError("Object with tag 'GlobalLight' not found.");
            }
        }
    }

    IEnumerator ActivateSeekerBook(UnityEngine.Rendering.Universal.Light2D playerLight)
    {
        // Store the initial sorting layer
        int initialSortingLayer = playerLight.lightOrder;

        Debug.Log("Initial Sorting Layer: " + initialSortingLayer);

        // Set the sorting layer to "Everything" temporarily
        playerLight.lightOrder = int.MaxValue;

        Debug.Log("Sorting Layer set to 'Everything'.");

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the sorting layer to the initial value
        playerLight.lightOrder = initialSortingLayer;

        Debug.Log("Sorting Layer reset to: " + initialSortingLayer);

        Destroy(gameObject); // Destroy the item after use.
        Debug.Log("SeekerBook item destroyed.");
    }
}
