using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    // Speed at which the Player will move
     public float moveSpeed = 10.0f;  // Set the default speed to 10.0f or any desired value
    public TextMeshProUGUI speedText;  // Reference to the UI Text element

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Get horizontal and vertical input from arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement based on input and speed
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Move the player based on the calculated movement
        transform.Translate(movement);

        if (speedText != null)
            speedText.text = "Speed: " + moveSpeed.ToString("F2");
        //other comments:
        //vector3 stores the x,y,z coordinate, for example (1.0f, 0.0f, 0.0f) will make the player to move 1 unit on the x axes
        //Time.deltaTime is making sure the rendering is smooth, and the movement speed is consistent between different devices, and it will make the animation smoother
        //transform.Translate is responsible for the actual translate between the code and making the player move on the screen by the given axis
    
    }
}
