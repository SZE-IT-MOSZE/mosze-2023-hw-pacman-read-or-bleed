using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    private bool _fireContinuously;
    private float _lastFireTime;

    public UnityEvent shootEvent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            _fireContinuously = true;
        }
        else if (Input.GetMouseButtonUp(0)) // Release the left mouse button
        {
            _fireContinuously = false;
        }

        if (_fireContinuously)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();

                _lastFireTime = Time.time;

                // Invoke the shoot events
                InvokeShootEvents();
            }
        }
    }

    private void FireBullet()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse cursor
        Vector3 fireDirection = (mousePosition - _gunOffset.position).normalized;

        // Calculate the rotation angle to look in the shooting direction with a 90-degree offset
        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg + 90f;

        // Create the bullet
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity to the normalized direction times the speed
        rigidbody.velocity = _bulletSpeed * fireDirection;
    }

    private void InvokeShootEvents()
    {
            shootEvent.Invoke();
        
    }
}