using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Game()
    {
        Debug.Log("Game mechanics testing map loaded");
        SceneManager.LoadScene("Game"); 
    }

    public void Dungeon()
    {
        Debug.Log("Dungeon testing map loaded!");
        SceneManager.LoadScene("Dungeon");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit(); 
    }
}
