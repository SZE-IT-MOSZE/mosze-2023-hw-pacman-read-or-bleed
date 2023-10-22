using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGruntAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessRadius = 5f;

    private Transform _player;

    private void Start()
    {
        // Find the player GameObject by tag
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }



    private void Update()
    {
        // Check if the player is within the specified awareness radius
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        AwareOfPlayer = distanceToPlayer <= _playerAwarenessRadius;

        if (AwareOfPlayer)
        {
            // Calculate the direction vector to the player
            DirectionToPlayer = (_player.position - transform.position).normalized;
        }
        else
        {
            DirectionToPlayer = Vector2.zero;
        }

        // Debug information
        Debug.Log("AwareOfPlayer: " + AwareOfPlayer);
        Debug.Log("DirectionToPlayer: " + DirectionToPlayer);
    }
}
