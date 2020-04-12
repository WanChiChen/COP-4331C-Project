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
    UIInventory uiInventory;
    UIAbilityBar abilityBar;

    public List<Item> characterItems = new List<Item>();
    public List<UIItem> uiItems = new List<UIItem>();
    public List<Ability> abilitiesList = new List<Ability>();
    public Ability[] barAbilities = new Ability[16];
    public List<UIAbility> uiAbilities = new List<UIAbility>();
    public int[] cooldowns = new int[16];
    public int[] usableAbilities = new int[16];
    public int damage;
    int[] slots = new int[4];
    Item[] equippedItems = new Item[4];
    public int startingHealth;
    public int currentHealth;
    public float speed;

    public bool newGame = false;

    // Update is called once per frame
    void Update()
    {

    }

    private void Start()
    {

    }

    public void updateProgress()
    {
        findObjects();
        characterItems = inventory.characterItems;
        //uiItems = uiInventory.uiItems;
        abilitiesList = abilities.abilities;
        barAbilities = abilities.barAbilities;
        cooldowns = abilities.cooldowns;
        usableAbilities = abilities.usableAbilities;
        uiAbilities = abilityBar.uiAbilities;
        damage = abilities.damage;
        slots = equip.slots;
        equippedItems = equip.equippedItems;
        startingHealth = health.startingHealth;
        currentHealth = health.currentHealth;
        speed = movement.speed;
    }

    public void loadProgress()
    {
        findObjects();
        inventory.characterItems = characterItems;
        //uiInventory.uiItems = uiItems;
        abilities.abilities = abilitiesList;
        abilities.barAbilities = barAbilities;
        abilities.cooldowns = cooldowns;
        abilities.usableAbilities = usableAbilities;
        abilityBar.uiAbilities = uiAbilities;
        abilities.damage = damage;
        equip.slots = slots;
        equip.equippedItems = equippedItems;
        health.startingHealth = startingHealth;
        health.currentHealth = currentHealth;
        movement.speed = speed;
    }

    public void loadDefault()
    {
        
        findObjects();
        //inventory.characterItems = new List<Item>();
        abilities.abilities = new List<Ability>();
        abilities.barAbilities = new Ability[16];
        abilities.cooldowns = new int[16];
        abilities.usableAbilities = new int[16];
        abilities.damage = 0;
        //abilityBar.uiAbilities = new List<UIAbility>();
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
        //uiInventory = GameObject.Find("InventoryPanel").GetComponent<UIInventory>();
        abilityBar = GameObject.Find("AbilityBarPanel").GetComponent<UIAbilityBar>();
    }
}
