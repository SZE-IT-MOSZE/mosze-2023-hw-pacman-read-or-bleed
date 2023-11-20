using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HealthController healthController; // Reference to the HealthController script.

    private void Start()
    {
        // Initialize the slider's value based on the remaining health percentage.
        float healthPercentage = healthController.RemainingHealthPercentage;
         Debug.Log("Health bar initialized. Current health percentage: " + healthPercentage);
    }

    // Update the slider's value when the health changes.
    public void UpdateHealthBar()
    {
        float healthPercentage = healthController.RemainingHealthPercentage;
       

        slider.value = healthPercentage;
        Debug.Log("Health bar updated. Current health percentage: " + healthPercentage);
    }
}
