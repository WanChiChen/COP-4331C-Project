using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyRoom : MonoBehaviour
{
    // Check if we have spawned on top of the origin room
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check tag, destroy the empty room if on origin room
        if(other.CompareTag("OriginRoom"))
        {
            Destroy(gameObject);
        }
    }
}
