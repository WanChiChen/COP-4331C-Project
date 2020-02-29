using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class EquipmentTest 
{
    [Test]
    public void testInitializeEquipment()
    {
        Equipment testEquipment;
        int[] attributes = new int[2];

        attributes[0] = 100;
        attributes[1] = 50;
        testEquipment = new Equipment(1, "TestEquipment", "TestDescription",
            new Dictionary<string, int>
            {
                {"TestAttribute", 1}
            },
            0, attributes);
        Assert.IsNotNull(testEquipment);
    }

    [Test]
    public void testCorrectAttributes()
    {
        Equipment testEquipment;
        int[] attributes = new int[2];

        attributes[0] = 100;
        attributes[1] = 50;
        testEquipment = new Equipment(1, "TestEquipment", "TestDescription",
            new Dictionary<string, int>
            {
                {"TestAttribute", 1}
            },
            0, attributes);

        Assert.AreEqual(attributes[0], testEquipment.attributes[0]);
        Assert.AreEqual(attributes[1], testEquipment.attributes[1]);
    }

    [Test]
    public void correctHealthModification()
    {
        Equipment testEquipment;
        PlayerEquip playerEquip;
        PlayerHealth playerHealth;
        GameObject player;
        int[] attributes = new int[2];
        int initialHealth, finalHealth;
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquip = player.GetComponent<PlayerEquip>();
        playerHealth = player.GetComponent<PlayerHealth>();
        attributes[0] = 100;
        attributes[1] = 50;
        testEquipment = new Equipment(1, "TestEquipment", "TestDescription", 
            new Dictionary<string, int>
            {
                {"TestAttribute", 1}
            }, 
            0, attributes);

        playerHealth.wakeUp();
        playerEquip.wakeUp();
        initialHealth = playerHealth.startingHealth;
        playerEquip.Equip(testEquipment);
        finalHealth = playerHealth.startingHealth;
        Assert.AreEqual(initialHealth + attributes[0], finalHealth);

    }

    [Test]
    public void correctSpeedModification()
    {
        Equipment testEquipment;
        PlayerEquip playerEquip;
        PlayerMovement playerMovement;
        GameObject player;
        int[] attributes = new int[2];
        float initialSpeed, finalSpeed;

        player = GameObject.FindGameObjectWithTag("Player");
        playerEquip = player.GetComponent<PlayerEquip>();
        playerMovement = player.GetComponent<PlayerMovement>();
        attributes[0] = 100;
        attributes[1] = 50;
        testEquipment = new Equipment(1, "TestEquipment", "TestDescription",
            new Dictionary<string, int>
            {
                {"TestAttribute", 1}
            },
            0, attributes);

        playerMovement.wakeUp();
        playerEquip.wakeUp();
        initialSpeed = playerMovement.speed;
        playerEquip.Equip(testEquipment);
        finalSpeed = playerMovement.speed;
        Assert.AreEqual(initialSpeed + attributes[1], finalSpeed);

    }
}
