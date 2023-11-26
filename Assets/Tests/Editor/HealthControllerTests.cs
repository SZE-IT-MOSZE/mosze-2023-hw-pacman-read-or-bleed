using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class HealthControllerTests
{

    [Test]
    public void TakeDamage_ReduceHealthByGivenAmount()
    {
        // Arrange
        var healthControllerObject = new GameObject().AddComponent<HealthController>();
        healthControllerObject._maximumHealth = 100f;
        healthControllerObject._currentHealth = 80f;

        // Act
        healthControllerObject.TakeDamage(20f);

        // Assert
        Assert.AreEqual(healthControllerObject._currentHealth, 60f);
    }

    [Test]
    public void AddHealth_IncreaseHealthByGivenAmount()
    {
        // Arrange
        var healthControllerObject = new GameObject().AddComponent<HealthController>();
        healthControllerObject._maximumHealth = 100f;
        healthControllerObject._currentHealth = 50f;

        // Act
        healthControllerObject.AddHealth(50f);

        // Assert
        Assert.AreEqual(healthControllerObject._currentHealth, 100f);
    }

    [Test]
    public void AddHealth_OverMaximumHealth_CurrentHealthSetToMaximumHealth()
    {
        // Arrange
        var healthControllerObject = new GameObject().AddComponent<HealthController>();
        healthControllerObject._maximumHealth = 100f;
        healthControllerObject._currentHealth = 80f;

        // Act
        healthControllerObject.AddHealth(30f);

        // Assert
        Assert.AreEqual(healthControllerObject._currentHealth, healthControllerObject._maximumHealth);
    }
}