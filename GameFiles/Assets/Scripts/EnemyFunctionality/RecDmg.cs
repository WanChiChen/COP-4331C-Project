using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecDmg : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int exp;
    public GameObject player;
    public int[] items = new int[3];
    public PlayerAbilities playerAbilities;
    public PlayerExperience playerExperience;
    public ItemDatabase db;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();
        playerExperience = player.GetComponent<PlayerExperience>();
        db = GameObject.FindGameObjectWithTag("ItemDB").GetComponent<ItemDatabase>();
    }

    // For testing purposes
    public void wakeUp()
    {
        Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= (damage + playerAbilities.damage);
        Variables.CurrentDPS += (damage + playerAbilities.damage);
        
        if((damage + playerAbilities.damage) > Variables.SingleTargetDPS)
        {
            Variables.SingleTargetDPS = (damage + playerAbilities.damage);
            Debug.Log("SingleTargetDPS: " + Variables.SingleTargetDPS);
        }

        CheckDeath();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private int generateLoot()
    {
        int rand = Random.Range(0, 3);
        return items[rand];
    }

    private void CheckDeath()
    {
        GameObject item = db.getItem(items[generateLoot()]).prefab;
        Vector3 bias = new Vector3(3, 0, 0);
        if (health <= 0)
        {
            Debug.Log("killed");
            playerExperience.collectExperience(exp);
            Destroy(gameObject);
            Instantiate(item, transform.position-bias, transform.rotation);
        }
    }

}
