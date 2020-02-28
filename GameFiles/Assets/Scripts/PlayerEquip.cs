using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    public GameObject player;
    PlayerHealth health;
    PlayerMovement movement;
    Weapon damage;
    int[] slots= new int[4];
    Equipment[] equippedItems = new Equipment[4];

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
    }

    public void Equip(Equipment equip)
    {
        int slot = equip.slot;
        if (slots[slot] > 0)
        {
            Unequip(slot);
        }
        slots[slot]++;

        health.startingHealth += equip.attributes[0];
        movement.speed += equip.attributes[1];
        equippedItems[slot] = equip;

    }

    public void Unequip(int slot)
    {
        Equipment unequipped;

        if(slots[slot] > 0)
        {
            unequipped = equippedItems[slot];
            health.startingHealth -= unequipped.attributes[0];
            movement.speed -= unequipped.attributes[1];

            slots[slot]--;
            equippedItems[slot] = null;
        }  
    }
}
