using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CameraFollowTests
{
    private CameraFollow cameraFollowScript;
    private GameObject playerObject;

    [SetUp]
    public void SetUp()
    {
        // Create a player GameObject for testing
        playerObject = new GameObject();
        cameraFollowScript = playerObject.AddComponent<CameraFollow>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.Destroy(playerObject);
    }

    [Test]
    public void CameraFollow_TargetsPlayerPosition()
    {
        // Arrange
        Transform playerTransform = playerObject.transform;
        cameraFollowScript.player = playerTransform;

        // Act
        Vector3 initialCameraPosition = cameraFollowScript.transform.position;
        cameraFollowScript.LateUpdate();
        Vector3 updatedCameraPosition = cameraFollowScript.transform.position;

        // Assert
        Assert.AreEqual(playerTransform.position.x, updatedCameraPosition.x, 0.001f, "X positions don't match");
        Assert.AreEqual(playerTransform.position.y, updatedCameraPosition.y, 0.001f, "Y positions don't match");
        Assert.AreEqual(initialCameraPosition.z, updatedCameraPosition.z, "Z positions should remain the same");
    }

    [Test]
    public void CameraFollow_AdjustsZoomSize()
    {
        // Arrange
        float newZoomSize = 7.0f;
        cameraFollowScript.zoomSize = newZoomSize;

        // Act
        cameraFollowScript.LateUpdate();
        float currentOrthographicSize = cameraFollowScript.GetComponent<Camera>().orthographicSize;

        // Assert
        Assert.AreEqual(newZoomSize, currentOrthographicSize, 0.001f, "Zoom size not adjusted correctly");
    }

    [Test]
    public void CameraFollow_DoesNotTargetNullPlayer()
    {
        // Arrange
        cameraFollowScript.player = null;
        Vector3 initialCameraPosition = cameraFollowScript.transform.position;

        // Act
        cameraFollowScript.LateUpdate();
        Vector3 updatedCameraPosition = cameraFollowScript.transform.position;

        // Assert
        Assert.AreEqual(initialCameraPosition, updatedCameraPosition, "Camera position should not change when player is null");
    }
}
