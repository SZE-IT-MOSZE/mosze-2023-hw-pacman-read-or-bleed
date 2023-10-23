using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    public UnityEvent attackEvent;
    public Transform player; // Reference to the player's transform.

    private void Start()
    {
        // You should set up the reference to the player here. 
        // You can find the player using a tag or other methods.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (IsPlayerCollision(collision))
        {
            InvokeAttackEvents();

            var healthController = collision.gameObject.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(_damageAmount);
            }
        }
    }
    private void InvokeAttackEvents()
    {
       
            attackEvent.Invoke();
    }

    private bool IsPlayerCollision(Collision2D collision)
    {
        // Check if the collision object has the "Player" tag.
        return collision.gameObject.CompareTag("Player");
    }
    
}