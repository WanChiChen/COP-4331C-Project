using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int id;

    public ItemDatabase itemDB;
    public Rigidbody2D rbody;
    public GameObject player;
    public Inventory inventory;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            Debug.LogError("Collided with player");
            inventory.collectItem(id);
            Destroy(this.gameObject);
            Debug.LogError("Destroyed");
        }
        
    }
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
