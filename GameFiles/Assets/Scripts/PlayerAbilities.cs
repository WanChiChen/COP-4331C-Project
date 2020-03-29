using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;
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

    public void wakeUp()
    {
        Awake();
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
        health.currentHealth += healthUpdate;
        if (health.currentHealth > health.startingHealth)
            health.currentHealth = health.startingHealth;
        movement.speed += movementUpdate;
        damage += damageUpdate;
    }

    void useSkill(Skill skill)
    {
        health.currentHealth += skill.modifiers[0];
        if (health.currentHealth > health.startingHealth)
            health.currentHealth = health.startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetButtonDown("Fire1"))
        {
            Shoot("Prefabs/bullet_prefab/bullet");
        }
        if (InputManager.GetButtonDown("Ability1"))
        {
            Shoot("Prefabs/bullet_prefab/ability1");
        }
        if (InputManager.GetButtonDown("Ability2"))
        {
            health.TakeDamage(-10);
        }
    }
    void Shoot(string prefabName)
    {
        bullet = Resources.Load<GameObject>(prefabName);
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
