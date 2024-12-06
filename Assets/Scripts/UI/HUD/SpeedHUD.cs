using UnityEngine;
using TMPro;

public class SpeedHUD : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Update()
    {
        // Find the player character by tag (assumes it's tagged as "Player")
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            UpdateSpeed();
        }
    }

    // Update the speed text in the HUD
    public void UpdateSpeed()
    {
        if (playerMovement != null)
        {
            // Find the TextMeshProUGUI component with the name "SpeedHUD" in the scene
            TextMeshProUGUI speedText = GameObject.Find("SpeedHUD").GetComponent<TextMeshProUGUI>();

            if (speedText != null)
            {
                speedText.text = "Speed: " + playerMovement.moveSpeed;
            }
        }
    }
}
