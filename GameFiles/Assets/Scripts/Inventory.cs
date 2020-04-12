using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Luminosity.IO;


public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDB;
    public UIInventory ui;
    
    public void collectItem(int id)
    {
        Item itemToAdd = itemDB.getItem(id);
        ui.addItem(itemToAdd);
        characterItems.Add(itemToAdd);
        Debug.Log("Item added:" + id);
    }

    public void collectItem(string id)
    {
        Item itemToAdd = itemDB.getItem(id);
        characterItems.Add(itemToAdd);
        ui.addItem(itemToAdd);
        Debug.Log("Item added:" + id);
    }

    public bool containsItem(int id)
    {
        foreach(Item item in characterItems)
        {
            if (item.id == id)
            {
                return true;
            }
        }

        return false;
    }

    public Item findItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void removeItem(int id)
    {
        if(containsItem(id))
        {
            characterItems.Remove(findItem(id));
            ui.removeItem(itemDB.getItem(id));
        }
    }

    private void Start()
    {
        characterItems = Variables.characterItems;
    }
}
