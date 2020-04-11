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
    public Ability[] barAbilities = new Ability[16];
    public int[] cooldowns = new int[16];
    public int[] usableAbilities = new int[16];
    public AbilityDatabase db;

    public Transform firepoint;
    public GameObject bullet;

    public int damage;

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
        /*
        learnAbility(db.getAbility(2));
        learnAbility(db.getAbility(3));
        learnAbility(db.getAbility(4));
        learnAbility(db.getAbility(5));
        learnAbility(db.getAbility(6));
        */
    }

    public void learnAbility(Ability ability)
    {
        int index;
        abilities.Add(ability);
        if (ability.type == 0)
        {
            updateStats(ability);
        }
        if (ability.type == 1 || ability.type == 2)
        {
            index = abilities.FindIndex(searchAbility => searchAbility == ability);
            cooldowns[index] = ability.modifiers[2];
            usableAbilities[index] = 1;
            barAbilities[index] = ability;
        }
    }

    public void learnAbility(int abilityID)
    {
        int index;
        Ability ability = db.getAbility(abilityID);
        abilities.Add(ability);
        if(ability.type == 0)
        {
            updateStats(ability);
        }
        if (ability.type == 1 || ability.type == 2)
        {
            index = abilities.FindIndex(searchAbility => searchAbility == ability);
            cooldowns[index] = ability.modifiers[2];
            usableAbilities[index] = 1;
            barAbilities[index] = ability;
        }
    }

    public void learnAbility(string title)
    {
        int index;
        Ability ability = db.getAbility(title);
        abilities.Add(ability);
        if (ability.type == 0)
        {
            updateStats(ability);
        }
        if(ability.type == 1 || ability.type == 2)
        {
            index = abilities.FindIndex(searchAbility => searchAbility == ability);
            cooldowns[index] = ability.modifiers[2];
            usableAbilities[index] = 1;
            barAbilities[index] = ability;
        }
    }

    void updateStats(Ability ability)
    {
        int healthUpdate = ability.modifiers[0];
        int movementUpdate = ability.modifiers[1];
        int damageUpdate = ability.modifiers[2];

        health.startingHealth += healthUpdate;
        health.currentHealth += healthUpdate;
        health.TakeDamage(0);
        if (health.currentHealth > health.startingHealth)
            health.currentHealth = health.startingHealth;
        movement.speed += movementUpdate;
        damage += damageUpdate;
    }

    public IEnumerator useAbility(int index)
    {
        Ability ability = barAbilities[index];
        if(usableAbilities[index] == 1)
        {
            health.TakeDamage(ability.modifiers[0] * -1);
            damage += ability.modifiers[1];
            if (ability.type == 2)
            {
                Shoot(ability.prefab);
            }
            usableAbilities[index] = 0;
            yield return new WaitForSecondsRealtime(cooldowns[index]);
            usableAbilities[index] = 1;
            damage -= ability.modifiers[1];
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
            StartCoroutine(useAbility(0));
        }
        if (InputManager.GetButtonDown("Ability2"))
        {
            StartCoroutine(useAbility(1));
        }
        if (InputManager.GetButtonDown("Ability3"))
        {
            StartCoroutine(useAbility(2));
        }
        if (InputManager.GetButtonDown("Ability4"))
        {
            StartCoroutine(useAbility(3));
        }
        if (InputManager.GetButtonDown("Ability5"))
        {
            StartCoroutine(useAbility(4));
        }
    }
    void Shoot(GameObject bullet)
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
