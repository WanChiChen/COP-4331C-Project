using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    public GameObject player;
    PlayerHealth health;
    PlayerMovement movement;
    PlayerAbilities damage;
    public int[] slots= new int[4];
    public Item[] equippedItems = new Item[4];

    /*
     * slots[0] = head armor
     * slots[1] = body armor
     * slots[2] = leg armor
     * slots[3] = feet armor
     */

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        movement = player.GetComponent<PlayerMovement>();
        damage = player.GetComponent<PlayerAbilities>();
    }

    public void Equip(Item equip)
    {
        int slot = equip.modifiers[0];
        if (slots[slot] > 0)
        {
            Unequip(slot);
        }
        slots[slot]++;

        health.startingHealth += equip.modifiers[1];
        health.TakeDamage(0);
        damage.damage += equip.modifiers[2];
        movement.speed += equip.modifiers[3];
        equippedItems[slot] = equip;

    }

    public void Unequip(int slot)
    {
        Item unequipped;

        if(slots[slot] > 0)
        {
            unequipped = equippedItems[slot];
            health.startingHealth -= unequipped.modifiers[1];
            health.TakeDamage(0);
            damage.damage -= unequipped.modifiers[2];
            movement.speed -= unequipped.modifiers[3];
            slots[slot]--;
            equippedItems[slot] = null;
        }  
    }

    public void wakeUp()
    {
        Awake();
    }
}
