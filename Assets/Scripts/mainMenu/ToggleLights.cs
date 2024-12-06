// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class LightController : MonoBehaviour
// {
//     public Toggle lightsToggle; // Reference to the Lights On/Off toggle.

//     private UnityEngine.Rendering.Universal.Light2D globalLight; // Reference to your Global Light 2D component.

//     // Static reference to the player object
//     private static GameObject playerObject;

//     private AudioListener audioListener; // Reference to the AudioListener component.

//     private void Start()
//     {
//         // Load the Global Light 2D from the other scene.
//         LoadGlobalLight();

//         // Ensure the initial state of the lights matches the toggle value.
//         ToggleLights();
//     }

//     private void LoadGlobalLight()
//     {
//         // Assuming "Game" is the name of the scene with your Global Light 2D.
//         string sceneName = "Game";

//         // Check if the scene is loaded, and load it if not.
//         if (!SceneManager.GetSceneByName(sceneName).isLoaded)
//         {
//             SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
//         }

//         // Find the Global Light 2D in the loaded scene.
//         GameObject globalLightObject = GameObject.Find("Global Light 2D"); // Replace with the actual name of your Global Light object.

//         // Assign the reference if found.
//         if (globalLightObject != null)
//         {
//             globalLight = globalLightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
//         }

//         // If the player object is not set, find it in the loaded scene.
//         if (playerObject == null)
//         {
//             playerObject = GameObject.FindGameObjectWithTag("Player");
//         }

//         // Don't destroy the player object when loading a new scene.
//         DontDestroyOnLoad(playerObject);

//         // Find or add an AudioListener component to the player object.
//         audioListener = playerObject.GetComponent<AudioListener>();
//         if (audioListener == null)
//         {
//             audioListener = playerObject.AddComponent<AudioListener>();
//         }
//     }

//     private void Update()
//     {
//         // Check for user input or any other conditions to open the options menu.
//         if (Input.GetKeyDown(KeyCode.Escape)) // Adjust this condition based on your input or UI triggers.
//         {
//             // Example: Load the options menu scene when the user presses the Escape key.
//             LoadOptionsMenu();
//         }
//     }

//     private void LoadOptionsMenu()
//     {
//         // Load the options menu scene. Adjust "OptionsMenu" with the actual name of your options menu scene.
//         SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Single);
//     }

//     public void ToggleLights()
//     {
//         if (globalLight != null && lightsToggle != null)
//         {
//             // Adjust the intensity of the Global Light based on the toggle value.
//             globalLight.intensity = lightsToggle.isOn ? 1f : 0f;
//         }

//         if (playerObject != null)
//         {
//             // Toggle the visibility of the Player object based on the toggle value.
//             playerObject.SetActive(lightsToggle.isOn);
//         }

//         // You might want to add additional logic for other lights or effects in your scene.

//         // If you want to change sorting layers, you can do it like this:
//         if (lightsToggle.isOn)
//         {
//             // Set the sorting layer for the Player object when lights are on.
//             SpriteRenderer playerRenderer = playerObject.GetComponent<SpriteRenderer>();
//             if (playerRenderer != null)
//             {
//                 playerRenderer.sortingLayerName = "Player";
//             }
//         }
//         else
//         {
//             // Set the sorting layer for the Player object when lights are off.
//             SpriteRenderer playerRenderer = playerObject.GetComponent<SpriteRenderer>();
//             if (playerRenderer != null)
//             {
//                 playerRenderer.sortingLayerName = "Default";
//             }
//         }
//     }
// }