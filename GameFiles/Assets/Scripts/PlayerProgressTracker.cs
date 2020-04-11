using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;
using UnityEngine.SceneManagement;

public class PlayerProgressTracker : MonoBehaviour
{
    GameObject player;
    PlayerAbilities abilities;
    PlayerHealth health;
    PlayerExperience exp;
    PlayerEquip equip;
    PlayerMovement movement;
    Inventory inventory;

    public List<Item> characterItems = new List<Item>();
    public List<Ability> abilitiesList = new List<Ability>();
    public Ability[] barAbilities = new Ability[16];
    public int[] cooldowns = new int[16];
    public int[] usableAbilities = new int[16];
    public int damage;
    int[] slots = new int[4];
    Item[] equippedItems = new Item[4];
    public int startingHealth;                    
    public int currentHealth;
    public float speed;

    public bool enteredPortal = false;
    // Update is called once per frame
    void Update()
    {
        if(enteredPortal == true)
        {
            loadProgress();
            enteredPortal = false;
        }
    }

    public void updateProgress()
    {
        findObjects();
        characterItems = inventory.characterItems;
        abilitiesList = abilities.abilities;
        barAbilities = abilities.barAbilities;
        cooldowns = abilities.cooldowns;
        usableAbilities = abilities.usableAbilities;
        damage = abilities.damage;
        slots = equip.slots;
        equippedItems = equip.equippedItems;
        startingHealth = health.startingHealth;
        currentHealth = health.currentHealth;
        speed = movement.speed;
    }

    public void loadProgress()
    {
        inventory.characterItems = characterItems;
        abilities.abilities = abilitiesList;
        abilities.barAbilities = barAbilities;
        abilities.cooldowns = cooldowns;
        abilities.usableAbilities = usableAbilities;
        abilities.damage = damage;
        equip.slots = slots;
        equip.equippedItems = equippedItems;
        health.startingHealth = startingHealth;
        health.currentHealth = currentHealth;
        movement.speed = speed;
        Debug.LogError(movement.speed + " " + speed);
    }

    public void loadDefault()
    {
        inventory.characterItems = new List<Item>();
        abilities.abilities = new List<Ability>();
        abilities.barAbilities = new Ability[16];
        abilities.cooldowns = new int[16];
        abilities.usableAbilities = new int[16];
        abilities.damage = 0;
        equip.slots = new int[4];
        equip.equippedItems = new Item[4];
        health.startingHealth = 100;
        health.currentHealth = 100;
        movement.speed = 4;
    }

    public void findObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        abilities = player.GetComponent<PlayerAbilities>();
        health = player.GetComponent<PlayerHealth>();
        exp = player.GetComponent<PlayerExperience>();
        equip = player.GetComponent<PlayerEquip>();
        movement = player.GetComponent<PlayerMovement>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
}
