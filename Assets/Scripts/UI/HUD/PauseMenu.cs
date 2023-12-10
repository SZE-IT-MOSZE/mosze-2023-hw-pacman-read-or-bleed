using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    void Start()
    {
        // Ensure the Pause menu is initially inactive
        SetChildrenActive(false);
    }

    void Update()
    {
        // Check for the Esc key to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        // Toggle the Pause menu and its children
        SetChildrenActive(isPaused);

        // Pause or unpause the game time
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void SetChildrenActive(bool isActive)
    {
        // Iterate through all child objects and set their active state
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}