using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        // Load the "Menu" scene when the button is clicked
        SceneManager.LoadScene("Menu");
    }
}