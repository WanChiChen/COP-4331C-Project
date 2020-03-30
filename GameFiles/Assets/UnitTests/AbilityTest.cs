using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Threading.Tasks;

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
        testAbility = new Ability(1, 0, "TestAbility", "AbilityDescription", modifiers);

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
        originalAbility = new Ability(1, 0, "TestAbility", "AbilityDescription", modifiers);
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

        testAbility = new Ability(1, 0, "TestAbility", "AbilityDescription", modifiers);
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

        testAbility = new Ability(1, 0, "TestAbility", "AbilityDescription", modifiers);
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

        testAbility = new Ability(1, 0, "TestAbility", "AbilityDescription", modifiers);
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

        testAbility = new Ability(1, 0, "TestAbility", "AbilityDescription", modifiers);
        playerAbilities.wakeUp();
        initialDamage = playerAbilities.damage;
        playerAbilities.learnAbility(testAbility);
        finalDamage = playerAbilities.damage; ;

        Assert.AreEqual(initialDamage + modifiers[2], finalDamage);
    }

    [Test]
    public void testActiveAbility()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerHealth playerHealth;
        GameObject player;
        int[] modifiers = new int[3];
        int initialHealth, finalHealth, index;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, 1, "TestAbility", "AbilityDescription", modifiers);
        playerHealth.wakeUp();
        playerAbilities.wakeUp();
        initialHealth = playerHealth.currentHealth;
        playerHealth.TakeDamage(30);
        playerAbilities.learnAbility(testAbility);
        index = playerAbilities.abilities.FindIndex(searchAbility => searchAbility == testAbility);
        playerAbilities.StartCoroutine(playerAbilities.useAbility(index));
        finalHealth = playerHealth.currentHealth;

        Assert.AreEqual(initialHealth - 30 + modifiers[0], finalHealth);
    }

    [Test]
    public void testActiveAbilityInitialUsability()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerHealth playerHealth;
        GameObject player;
        int[] modifiers = new int[3];
        int initialUsability, finalUsability, index;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, 1, "TestAbility", "AbilityDescription", modifiers);
        playerHealth.wakeUp();
        playerAbilities.wakeUp();
        playerAbilities.learnAbility(testAbility);
        index = playerAbilities.abilities.FindIndex(searchAbility => searchAbility == testAbility);
        initialUsability = playerAbilities.usableAbilities[index];
        playerAbilities.StartCoroutine(playerAbilities.useAbility(index));
        finalUsability = playerAbilities.usableAbilities[index];

        Assert.AreEqual(initialUsability, 1);
    }

    [Test]
    public void testActiveAbilityUnusableOnCooldown()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerHealth playerHealth;
        GameObject player;
        int[] modifiers = new int[3];
        int initialUsability, finalUsability, index;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 30;

        testAbility = new Ability(1, 1, "TestAbility", "AbilityDescription", modifiers);
        playerHealth.wakeUp();
        playerAbilities.wakeUp();
        playerAbilities.learnAbility(testAbility);
        index = playerAbilities.abilities.FindIndex(searchAbility => searchAbility == testAbility);
        initialUsability = playerAbilities.usableAbilities[index];
        playerAbilities.StartCoroutine(playerAbilities.useAbility(index));
        finalUsability = playerAbilities.usableAbilities[index];

        Assert.AreEqual(finalUsability, 0);
    }

    [Test]
    public void testActiveAbilityUsableAfterCooldown()
    {
        Ability testAbility;
        PlayerAbilities playerAbilities;
        PlayerHealth playerHealth;
        GameObject player;
        int[] modifiers = new int[3];
        int initialUsability, finalUsability, index;
        Task useAbility;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        modifiers[0] = 10;
        modifiers[1] = 20;
        modifiers[2] = 1;

        testAbility = new Ability(1, 1, "TestAbility", "AbilityDescription", modifiers);
        playerHealth.wakeUp();
        playerAbilities.wakeUp();
        playerAbilities.learnAbility(testAbility);
        index = playerAbilities.abilities.FindIndex(searchAbility => searchAbility == testAbility);
        initialUsability = playerAbilities.usableAbilities[index];
        useAbility = Task.Run(() =>
        {
            playerAbilities.StartCoroutine(playerAbilities.useAbility(index));  
        });
        finalUsability = playerAbilities.usableAbilities[index];

        Assert.AreEqual(finalUsability, 1);
    }
}
