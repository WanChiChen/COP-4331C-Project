using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : EnemyAttack
{
    public float damage;
    public Rigidbody2D body;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            print("melee hit");
            if (collision.GetComponent<PlayerHealth>() != null)
            {
                print("melle hit this" + collision.tag);
                int dmg = Mathf.FloorToInt(damage);
                collision.GetComponent<PlayerHealth>().TakeDamage(dmg);
            }
        }
    }
    
    
}
   



