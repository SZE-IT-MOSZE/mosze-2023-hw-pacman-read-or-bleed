using UnityEngine;
 // Add this using directive for Light2D
using TMPro;

public class VisionHUD : MonoBehaviour
{
    private void Update()
    {
        // Find the player character by tag (assumes it's tagged as "Player")
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            UnityEngine.Rendering.Universal.Light2D playerLight = player.GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();

            if (playerLight != null)
            {
                // Find the TextMeshProUGUI component with the name "VisionText" in the scene
                TextMeshProUGUI visionText = GameObject.Find("VisionHUD").GetComponent<TextMeshProUGUI>();

                if (visionText != null)
                {
                    visionText.text = "Vision: " + playerLight.pointLightOuterRadius;
                }
            }
        }
    }
}
