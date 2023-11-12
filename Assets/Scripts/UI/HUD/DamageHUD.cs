using UnityEngine;
using TMPro;

public class DamageHUD : MonoBehaviour
{
    private PlayerDamageController damageController;

    private void Update()
    {
        // Find the player character by tag (assumes it's tagged as "Player")
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            damageController = player.GetComponent<PlayerDamageController>();
            UpdateDamage();
        }
    }

    // Update the damage text in the HUD
    public void UpdateDamage()
    {
        if (damageController != null)
        {
            // Find the TextMeshProUGUI component with the name "DamageHUD" in the scene
            TextMeshProUGUI damageText = GameObject.Find("DamageHUD").GetComponent<TextMeshProUGUI>();

            if (damageText != null)
            {
                damageText.text = "Damage: " + damageController.GetPlayerDamage();
            }
        }
    }
}
