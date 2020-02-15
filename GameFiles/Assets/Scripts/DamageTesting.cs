using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTesting : MonoBehaviour
{

    public int attackDamage = 10;
    GameObject player;
    PlayerHealth playerHealth;
    // Start is called before the first frame update

    void Awake()
    {
       player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
            playerHealth.TakeDamage(attackDamage);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
