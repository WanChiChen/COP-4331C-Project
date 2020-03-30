using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;
    public Rigidbody2D body;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag != "Enemy" && collision.tag != "roomSpawner" && collision.tag != "OriginRoom" && collision.tag != "Item")
        {
            if (collision.GetComponent<RecDmg>() != null)
            {
                print(collision.tag);
                collision.GetComponent<RecDmg>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    
        
}
