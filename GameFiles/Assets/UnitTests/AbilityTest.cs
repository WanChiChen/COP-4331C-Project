using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class AbilityTest 
{
    [Test]
    public void testInitializeAbility()
    {
        Ability testAbility;
        int[] modifiers = new int[3];

        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;
        testAbility = new Ability(1, "TestAbility", "AbilityDescription", modifiers);

        Assert.IsNotNull(testAbility);
    }

    [Test]
    public void testDuplicateAbility()
    {
        Ability originalAbility, testAbility;
        int[] modifiers = new int[3];

        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;
        originalAbility = new Ability(1, "TestAbility", "AbilityDescription", modifiers);
        testAbility = new Ability(originalAbility);

        Assert.IsNotNull(testAbility);
    }

    [Test]
    public void testCorrectStartingHealthModification()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerHealth playerHealth;
        GameObject player;
        int[] modifiers = new int[3];
        int initialHealth, finalHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, "TestAbility", "AbilityDescription", modifiers);
        playerHealth.wakeUp();
        playerAbilities.wakeUp();
        initialHealth = playerHealth.startingHealth;
        playerAbilities.learnAbility(testAbility);
        finalHealth = playerHealth.startingHealth;
        

        Assert.AreEqual(initialHealth+modifiers[0], finalHealth);
    }

    [Test]
    public void testCorrectCurrentHealthModification()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerHealth playerHealth;
        GameObject player;
        int[] modifiers = new int[3];
        int initialHealth, finalHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, "TestAbility", "AbilityDescription", modifiers);
        playerHealth.wakeUp();
        playerAbilities.wakeUp();
        initialHealth = playerHealth.currentHealth;
        playerHealth.TakeDamage(30);
        playerAbilities.learnAbility(testAbility);
        finalHealth = playerHealth.currentHealth;

        Assert.AreEqual(initialHealth-30+modifiers[0], finalHealth);
    }

    [Test]
    public void testCorrectSpeedModification()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerMovement playerMovement;
        GameObject player;
        int[] modifiers = new int[3];
        float initialSpeed, finalSpeed;

        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();
        playerMovement = player.GetComponent<PlayerMovement>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, "TestAbility", "AbilityDescription", modifiers);
        playerMovement.wakeUp();
        playerAbilities.wakeUp();
        initialSpeed = playerMovement.speed;
        playerAbilities.learnAbility(testAbility);
        finalSpeed = playerMovement.speed;

        Assert.AreEqual(initialSpeed + modifiers[1], finalSpeed);
    }

    [Test]
    public void testCorrectDamageModification()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        GameObject player;
        int[] modifiers = new int[3];
        int initialDamage, finalDamage;

        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, "TestAbility", "AbilityDescription", modifiers);
        playerAbilities.wakeUp();
        initialDamage = playerAbilities.damage;
        playerAbilities.learnAbility(testAbility);
        finalDamage = playerAbilities.damage; ;

        Assert.AreEqual(initialDamage + modifiers[2], finalDamage);
    }
}
