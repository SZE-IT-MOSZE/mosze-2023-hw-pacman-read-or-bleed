using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
   //I recommend 7 for the move speed, and 1.2 for the force damping
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;
    public Animator animator;

public Transform spotlightTransform; // Drag and drop the 2D Light GameObject here
    public Vector3 offset; // The offset to adjust the spotlight's position

    private bool canMove = true; // Flag to control player movement
    public GameObject diedHUD;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
       // Set the "Horizontal" and "Vertical" parameters in the Animator
        animator.SetFloat("Horizontal", PlayerInput.x);
        animator.SetFloat("Vertical", PlayerInput.y);

        // Set the "Speed" parameter based on the magnitude of PlayerInput
        animator.SetFloat("Speed", PlayerInput.sqrMagnitude);

        // Calculate the desired spotlight position
        Vector3 characterCenter = transform.position + offset;
        characterCenter.z = spotlightTransform.position.z; // Preserve the original z-position
        spotlightTransform.position = characterCenter;
    }

     void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 moveForce = PlayerInput * moveSpeed;
            moveForce += forceToApply;
            forceToApply /= forceDamping;

            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
            {
                forceToApply = Vector2.zero;
            }

            rb.velocity = moveForce;
        }
    }
    

    // Collision handling
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character is colliding with an object tagged as "Wall"
         // Check if the character is colliding with an object tagged as "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
        // Debug log for testing
        Debug.Log("Collision with wall detected");

        // Stop the character from moving by setting velocity to zero
        rb.velocity = Vector2.zero;
        }
    }

     public void DisableMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero; // Stop the player's movement.
        // You can add any other necessary actions when movement is disabled.
    }

    // Method to enable player movement
    public void EnableMovement()
    {
        canMove = true;
        // You can add any other necessary actions when movement is enabled.
    }

    public void PlayDeathAnimation()
    {
        // Add any additional logic or actions before playing the death animation.
        animator.SetTrigger("Death"); // Adjust the parameter name as per your Animator setup.
        // You may want to disable movement during the death animation, depending on your game design.
        

        // Enable DiedHUD at runtime

        if (diedHUD != null)
        {
            diedHUD.SetActive(true);
        }
        else
        {
            Debug.LogError("DiedHUD not assigned! Assign the DiedHUD object in the Unity editor.");
        }

DisableMovement();
    }
    
}
