using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class InvincibilityControllerTests
{
    private GameObject testObject;
    public InvincibilityController invincibilityController;
    private HealthController healthController;

    [SetUp]
    public void SetUp()
    {
        testObject = new GameObject("TestObject");
        healthController = testObject.AddComponent<HealthController>();
        invincibilityController = testObject.AddComponent<InvincibilityController>();
        invincibilityController.enabled = false; // Disable the script by default
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(testObject);
    }

    [UnityTest]
    public IEnumerator StartInvincibility_EnablesAndDisablesInvincibility()
    {
        invincibilityController.enabled = true; // Enable the script

        float invincibilityDuration = 2.0f;

        invincibilityController.StartInvincibility(invincibilityDuration);

        Assert.IsTrue(healthController.IsInvincible, "Health should be invincible after StartInvincibility");

        yield return new WaitForSeconds(invincibilityDuration + 0.1f);

        Assert.IsFalse(healthController.IsInvincible, "Health should not be invincible after invincibility duration");
    }
}
