﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class bullet : MonoBehaviour
{

    public float speed = 10;
    public Rigidbody2D body;
    public float dmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        // Check if trigger is a room spawner node or origin node
        if (!collision.CompareTag("roomSpawner") && !collision.CompareTag("OriginRoom") && !collision.CompareTag("Item"))
        {
            Debug.Log("Bullet collided with " + collision.gameObject.name, collision.gameObject);
            Destroy(gameObject);
        }
    }
   
    private void Update()
    {
        if (body.position.x > 50 || body.position.y > 50 || body.position.x < -50 || body.position.y < -50)
        {
            Debug.Log("Bullet too far");
            Destroy(gameObject);
        }
    }
}