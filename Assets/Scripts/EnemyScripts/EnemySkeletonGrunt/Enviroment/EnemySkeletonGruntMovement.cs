using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float chaseSpeed = 3.0f; // Adjust this to set the chase speed.
    [SerializeField]
    private float wanderingSpeed = 1.0f; // Adjust this for wandering speed.
    [SerializeField]
    private float changeDirectionCooldownMin = 1f;
    [SerializeField]
    private float changeDirectionCooldownMax = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 targetDirection;
    private float changeDirectionCooldown;

    private Transform player; // Reference to the player's Transform.

    [SerializeField]
    private SkeletonGruntAwarenessController skeletonGruntAwarenessController;

    private bool hasPlayedDeathAnimation = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        skeletonGruntAwarenessController = GetComponent<SkeletonGruntAwarenessController>();
        targetDirection = transform.up;
    }

    private void Start()
    {
        // Find the player GameObject and get its Transform component.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has a tag 'Player'.");
        }
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if (changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(changeDirectionCooldownMin, changeDirectionCooldownMax);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (skeletonGruntAwarenessController.AwareOfPlayer)
        {
            targetDirection = skeletonGruntAwarenessController.DirectionToPlayer;
        }
    }

    private void SetVelocity()
    {
        float speed = skeletonGruntAwarenessController.AwareOfPlayer ? chaseSpeed : wanderingSpeed;
        rb.velocity = targetDirection.normalized * speed;

        animator.SetFloat("Horizontal", targetDirection.x);
        animator.SetFloat("Vertical", targetDirection.y);
        animator.SetFloat("Speed", speed);
    }

    public void DisableMovement()
{
    rb.velocity = Vector2.zero; // Stop the enemy's movement.
    enabled = false; // Disable the script.
}

public void PlayDeathAnimation()
    {
        if (!hasPlayedDeathAnimation)
        {
            // Play the death animation here.
            animator.SetTrigger("Death"); // Adjust the parameter name as per your Animator setup.
            hasPlayedDeathAnimation = true;
        }
    }

}
