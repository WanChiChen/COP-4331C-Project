using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerDeathTest
{
    [Test]
    public void PlayerCanBeDamaged()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth health = player.GetComponent<PlayerHealth>();

        health.currentHealth = health.startingHealth;
        int expected = health.currentHealth - 1;
        health.TakeDamage(1);
        Assert.AreEqual(health.currentHealth, expected);
    }

    [Test]
    public void PlayerCanDie()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.InitializeMovement();
        health.currentHealth = health.startingHealth;
        health.TakeDamage(health.currentHealth);

        Assert.AreEqual(false, health.isAlive());

    }
}