using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : Ability
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public int[] modifiers = new int[2];
    public int cooldown;
    /*
     * modifier[0] = adds this amount to player health on use
     * modifier[1] = does this amount of damage
     * modifier[2] = idk
     */

    public Skill(int id, string title, string description, int[] modifiers, int cooldown) : base(id, title, description, modifiers)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/TestItem");
        this.modifiers = modifiers;
        this.cooldown = cooldown;
    }

    public Skill(Skill skill) : base(skill.id, skill.title, skill.description, skill.modifiers)
    {
        this.id = skill.id;
        this.title = skill.title;
        this.description = skill.description;
        this.icon = skill.icon;
        this.modifiers = skill.modifiers;
        this.cooldown = skill.cooldown;
    }
}
