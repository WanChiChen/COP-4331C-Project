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
    SkillCanvas skillCanvas;

    // Update is called once per frame
    void Update()
    {

    }

    private void Start()
    {

    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            abilities = player.GetComponent<PlayerAbilities>();
            health = player.GetComponent<PlayerHealth>();
            exp = player.GetComponent<PlayerExperience>();
            equip = player.GetComponent<PlayerEquip>();
            movement = player.GetComponent<PlayerMovement>();
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            uiInventory = GameObject.Find("InventoryPanel").GetComponent<UIInventory>();
            abilityBar = GameObject.Find("AbilityBarPanel").GetComponent<UIAbilityBar>();
            //skillCanvas = GameObject.Find("SkillPanel").GetComponent<SkillCanvas>();
        }
    }

    public void updateProgress()
    {   
        findObjects();
        Variables.startingHealth = health.startingHealth;
        Variables.currentHealth = health.currentHealth;
        Variables.speed = movement.speed;
        Variables.exp = exp.exp;
        Variables.level = exp.level;
        Variables.expThreshold = exp.expThreshold;
        Variables.skillPoints = exp.skillPoints;
        Variables.totalSkillPoints = exp.totalSkillPoints;
        Variables.damage = abilities.damage;
        //Variables.cooldowns = abilities.cooldowns;
    }

    public void findObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        abilities = player.GetComponent<PlayerAbilities>();
        health = player.GetComponent<PlayerHealth>();
        exp = player.GetComponent<PlayerExperience>();
        equip = player.GetComponent<PlayerEquip>();
        movement = player.GetComponent<PlayerMovement>();
    }
}
