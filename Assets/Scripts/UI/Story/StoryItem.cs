using UnityEngine;
using TMPro;

public class StoryItem : MonoBehaviour
{
    public string storyTextFileName; // The name of the .txt file for the story text.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StoryManager storyManager = FindObjectOfType<StoryManager>();
            if (storyManager != null)
            {
                // Load and display the story text from the .txt file associated with this story item.
                string storyText = LoadStoryText();
                storyManager.ToggleDialog(true);
                storyManager.storyText.text = storyText;
                storyManager.SetPlayerCollider(other); // Set the player's collider.
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StoryManager storyManager = FindObjectOfType<StoryManager>();
            if (storyManager != null)
            {
                storyManager.SetPlayerCollider(null); // Remove the player's collider.
            }
        }
    }

    private string LoadStoryText()
    {
        // Specify the path to the .txt file using Resources.Load.
        string filePath = "StoryTexts/" + storyTextFileName;
        TextAsset textAsset = Resources.Load<TextAsset>(filePath);

        if (textAsset != null)
        {
            return textAsset.text;
        }
        else
        {
            Debug.LogError("Story text file not found: " + filePath);
            return "Story text not available";
        }
    }
}
