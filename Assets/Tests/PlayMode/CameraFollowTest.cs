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
