using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;
    public Rigidbody2D body;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag != "Enemy" && collision.tag != "roomSpawner" && collision.tag != "OriginRoom" && collision.tag != "Item" && collision.tag != "Exit")
        {
            if (collision.GetComponent<PlayerHealth>() != null)
            {
                print(collision.tag);
                int dmg = Mathf.FloorToInt(damage);
                collision.GetComponent<PlayerHealth>().TakeDamage(dmg);
            }
            Destroy(gameObject);
        }
    }
    
        
}
