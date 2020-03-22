using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public int[] modifiers = new int[3];
    /*
     * modifier[0] = health modifier
     * modifier[1] = speed modifier
     * modifier[2] = damage modifier
     */

    public Ability(int id, string title, string description, int[] modifiers)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/TestItem");
        this.modifiers = modifiers;
    }

    public Ability(Ability ability)
    {
        this.id = ability.id;
        this.title = ability.title;
        this.description = ability.description;
        this.icon = ability.icon;
        this.modifiers = ability.modifiers;
    }

}
