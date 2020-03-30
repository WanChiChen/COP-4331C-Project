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
    public AbilityDatabase db;

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

    private void Start()
    {
        learnAbility(db.getAbility(1));
        learnAbility(db.getAbility(3));
    }

    public void learnAbility(Ability ability)
    {
        abilities.Add(ability);
        if (ability.type == 0)
        {
            updateStats(ability);
        }
    }

    public void learnAbility(int abilityID)
    {
        Ability ability = db.getAbility(abilityID);
        abilities.Add(ability);
        if(ability.type == 0)
        {
            updateStats(ability);
        }
    }

    public void learnAbility(string title)
    {
        Ability ability = db.getAbility(title);
        abilities.Add(ability);
        if (ability.type == 0)
        {
            updateStats(ability);
        }
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

    void useAbility(Ability ability)
    {
        health.TakeDamage(ability.modifiers[0] * -1);
        if(ability.type == 2)
        {
            Shoot(ability.prefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetButtonDown("Fire1"))
        {
            bullet = Resources.Load<GameObject>("Prefabs/bullet_prefab/bullet");
            Shoot(bullet);
        }
        if (InputManager.GetButtonDown("Ability1"))
        {
            useAbility(abilities[0]);
        }
        if (InputManager.GetButtonDown("Ability2"))
        {
            useAbility(abilities[1]);
        }
    }
    void Shoot(GameObject bullet)
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }

    void swapAbilityPosition(int index1, int index2)
    {
        Ability temp = abilities[index2];
        abilities[index2] = abilities[index1];
        abilities[index1] = temp;
    }
}
