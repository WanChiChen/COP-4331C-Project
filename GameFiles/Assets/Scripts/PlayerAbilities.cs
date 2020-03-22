using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject player;
    PlayerHealth health;
    PlayerMovement movement;
    public List<Ability> abilities = new List<Ability>();
    AbilityDatabase db;

    public Transform firepoint;
    public GameObject bullet;

    public int damage = 1;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent<PlayerMovement>();
    }

    public void learnAbility(Ability ability)
    {
        abilities.Add(ability);
        updateStats(ability);
    }

    public void learnAbility(int abilityID)
    {
        Ability ability = db.getAbility(abilityID);
        abilities.Add(ability);
        updateStats(ability);
    }

    public void learnAbility(string title)
    {
        Ability ability = db.getAbility(title);
        abilities.Add(ability);
        updateStats(ability);
    }

    void updateStats(Ability ability)
    {
        int healthUpdate = ability.modifiers[0];
        int movementUpdate = ability.modifiers[1];
        int damageUpdate = ability.modifiers[2];

        health.startingHealth += healthUpdate;
        movement.speed += movementUpdate;
        damage += damageUpdate;
    }

    void useSkill(Skill skill)
    {
        health.currentHealth += skill.modifiers[0];
        if (health.currentHealth > health.startingHealth)
            health.currentHealth = health.startingHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
       
    }
    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
