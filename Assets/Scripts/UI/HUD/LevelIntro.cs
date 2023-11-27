using System.Collections;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    public string levelIntroTag = "LevelIntro"; // Set this to the tag you're using

    void Start()
    {
        // Find the GameObject with the specified tag
        GameObject levelIntroObject = GameObject.FindGameObjectWithTag(levelIntroTag);

        // Ensure the GameObject is initially inactive
        SetChildrenActive(false);

        // Start the coroutine
        StartCoroutine(ShowLevelIntro());
    }

    IEnumerator ShowLevelIntro()
    {
        // Make LevelIntro and all its children visible
        SetChildrenActive(true);

        // Display time
        yield return new WaitForSeconds(3.5f);

        // Disable LevelIntro and all its children
        SetChildrenActive(false);
    }

    void SetChildrenActive(bool isActive)
    {
        // Set the active state for all children of LevelIntro
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
