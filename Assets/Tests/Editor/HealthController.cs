using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    public float _currentHealth;

    [SerializeField]
    public float _maximumHealth;
    
    public float CurrentHealth // Make the health value accessible
    {
        get { return _currentHealth; }
    }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    private bool isDead = false; // Flag to track if the character is already dead.

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0 || isDead)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            isDead = true; // Set the flag to prevent further death event invocation.
            OnDied.Invoke();

    
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }
}
