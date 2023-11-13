using UnityEngine;
using TMPro;

public class HealthHUD : MonoBehaviour
{
    private HealthController healthController;

    private void Update()
    {
        // Find the player character by tag (assumes it's tagged as "Player")
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            healthController = player.GetComponent<HealthController>();
            UpdateHealth();
        }
    }

    // Update the health text in the HUD
    public void UpdateHealth()
    {
        if (healthController != null)
        {
            // Find the TextMeshProUGUI component with the name "HealthText" in the scene
            TextMeshProUGUI healthText = GameObject.Find("HealthHUD").GetComponent<TextMeshProUGUI>();

            if (healthText != null)
            {
                healthText.text = "Health: " + healthController.CurrentHealth;
            }
        }
    }
}
