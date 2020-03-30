using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class bullet : MonoBehaviour
{
    GameObject player;
    PlayerAbilities skill;
    public float speed = 10;
    public Rigidbody2D body;
    public float dmg;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        skill = player.GetComponent<PlayerAbilities>();
    }

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
        
        //collides with enemy
        if(collision.CompareTag("Enemy"))
        {
            if(collision.GetComponent<RecDmg>() != null)
            {
                collision.GetComponent<RecDmg>().DealDamage(dmg);
            }
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