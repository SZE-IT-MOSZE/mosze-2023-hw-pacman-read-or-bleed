using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float followSpeed = 5.0f; // Adjust the follow speed
    public float zoomSize = 5.0f; // Adjust the zoom size

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the new camera position by interpolating between the current position and the player's position
            Vector3 targetPosition = Vector3.Lerp(transform.position, player.position, Time.deltaTime * followSpeed);
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);

            // Adjust the camera size for zoom
            mainCamera.orthographicSize = zoomSize;
        }
    }
}