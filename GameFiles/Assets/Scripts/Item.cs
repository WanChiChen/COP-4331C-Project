using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public int type; //0 for usable item, //1 for equipment
    public string title;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public int[] modifiers = new int[4];
    /*
     * usable item:
     * modifier[0] = health modifier
     * modifier[1] = damage modifier
     * modifier[2] = movement modifier
     * modifier[3] = exp modifier
     * 
     * equipment:
     * modifier[0] = slot
     * modifier[1] = health modifier
     * modifier[2] = damage modifier
     * modifier[3] = movement modifier
     * 
     */

    public Item(int id, int type, string title, string description, int[] modifiers)
    {
        this.id = id;
        this.type = type;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
        this.modifiers = modifiers;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.type = item.type;
        this.title = item.title;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.title);
        this.modifiers = item.modifiers;
    }
}
