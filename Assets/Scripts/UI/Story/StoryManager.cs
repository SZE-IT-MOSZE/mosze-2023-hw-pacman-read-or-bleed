using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI storyText;
    private bool inDialog = false;
    private Collider2D playerCollider; // Reference to the player's collider.

    private void Start()
    {
        // Initialize the panel and dialog to be hidden at the start.
        ToggleDialog(false);
    }

    private void Update()
    {
        if (inDialog && playerCollider == null)
        {
            // Hide the dialog when the player leaves the item's trigger zone.
            ToggleDialog(false);
        }
    }

    public void ToggleDialog(bool show)
    {
        inDialog = show;
        panel.SetActive(show);
        storyText.gameObject.SetActive(show);
    }

    public void SetPlayerCollider(Collider2D collider)
    {
        playerCollider = collider;
    }
}
