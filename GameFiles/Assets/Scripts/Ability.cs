using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public int id;
    public int type; //0 for passive, 1 for active, 2 for attack
    public int cost;
    public string title;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public int[] modifiers = new int[3];
    /*
     * passive ability:
     * modifier[0] = health modifier
     * modifier[1] = speed modifier
     * modifier[2] = damage modifier
     * 
     * active ability:
     * modifier[0] = health modifier
     * modifier[1] = damage modifier
     * modifier[2] = cooldown
     * 
     * damage ability:
     * modifier[0] = health modifier
     * modifier[1] = damage done
     * modifier[2] = cooldown
     * 
     */

    public Ability(int id, int type, int cost, string title, string description, int[] modifiers)
    {
        this.id = id;
        this.type = type;
        this.cost = cost;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Abilities/"+title);
        this.prefab = Resources.Load<GameObject>("Prefabs/bullet_prefab/"+title);
        this.modifiers = modifiers;
    }

    public Ability(Ability ability)
    {
        this.id = ability.id;
        this.type = ability.type;
        this.cost = ability.cost;
        this.title = ability.title;
        this.description = ability.description;
        this.icon = ability.icon;
        this.prefab = ability.prefab;
        this.modifiers = ability.modifiers;
    }

}
