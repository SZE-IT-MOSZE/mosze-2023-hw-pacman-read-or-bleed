using UnityEngine;

public class WinHUD : MonoBehaviour
{
    // Method to enable the WinningHUD and its child objects with a delay
    public void ShowWinScreen()
    {
        StartCoroutine(SetWinScreenAfterDelay());
    }

    // Coroutine to wait for a specified time before enabling the WinningHUD
    private System.Collections.IEnumerator SetWinScreenAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SetWinScreenActive(true);
    }

    // Method to disable the WinningHUD and its child objects
    public void HideWinScreen()
    {
        SetWinScreenActive(false);
    }

    // Recursive method to toggle the active state of the WinningHUD and all its child objects
    private void SetWinScreenActive(bool isActive)
    {
        SetActiveRecursively(gameObject, isActive);
    }

    // Recursive method to set the active state of a GameObject and its children
    private void SetActiveRecursively(GameObject obj, bool isActive)
    {
        obj.SetActive(isActive);

        // Iterate through child objects and set their active state recursively
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursively(child.gameObject, isActive);
        }
    }
}
