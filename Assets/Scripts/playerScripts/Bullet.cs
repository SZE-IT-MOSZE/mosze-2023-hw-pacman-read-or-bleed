using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            // Destroy the bullet when it hits a wall
            Destroy(gameObject);
        }
        // else if (collision.GetComponent<EnemyMovement>())
        // {
        //     Destroy(collision.gameObject);
        //     Destroy(gameObject);
        // }
         Debug.DrawLine(transform.position, collision.transform.position, Color.red, 1f);
    }
}
