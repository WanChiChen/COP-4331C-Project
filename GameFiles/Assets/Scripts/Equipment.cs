using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public int slot; // which equipment slot this item takes up
    public int[] attributes; // array of length 2
        /*
         * attributes[0] = health modifier
         * attributes[1] = speed modifier
         */

    public Equipment(int id, string title, string description, Dictionary<string, int> stats, int slot, int[] attributes) : base(id, title, description, stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/TestItem");
        this.stats = stats;
        this.slot = slot;
        this.attributes = attributes;
    }

}
