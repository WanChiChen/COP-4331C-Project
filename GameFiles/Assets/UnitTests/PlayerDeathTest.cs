using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

// Tests that player can properly die
public class PlayerDeathTest
{
    [Test]
    public void PlayerCanBeDamaged() // Tests that player health can be lowered
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth health = player.GetComponent<PlayerHealth>();

        health.currentHealth = health.startingHealth;
        int expected = health.currentHealth - 1;
        health.TakeDamage(1);
        Assert.AreEqual(health.currentHealth, expected);
    }

    [Test]
    public void PlayerCanDie() // Tests that player dies when health reaches 0
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.InitializeMovement();
        health.currentHealth = health.startingHealth;
        health.TakeDamage(health.currentHealth);

        Assert.AreEqual(false, health.isAlive());

    }
}