using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDatabase : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    // Start is called before the first frame update
    public void BuildDatabase()
    {
        abilities = new List<Ability>()
        {
            new Ability(1, 0, 1, "Hit the Gym", "Slightly Raises Base Stats", new int[]{4,4,4}),
            new Ability(2, 1, 1, "Bandaids", "Slightly Restores Health", new int[]{10,10,5}),
            new Ability(3, 2, 1, "Pew Pew", "High Damage at Cost of Health", new int[]{-10,110,5}),
            new Ability(4, 1, 1, "Life Tap", "Damage Boost at Cost of Health", new int[]{-10,50,5}),
            new Ability(5, 1, 1, "Stay Hydrated", "Large Health Recovery at Cost of Lower Damage Dealt", new int[]{50,-10,5}),
            new Ability(6, 2, 1, "Bowling Ball", "Slow Moving, High Damage Projectile", new int[]{0,200,7}),
            new Ability(7, 2, 1, "Overpowered", "Overpowered Ability", new int[]{50,1000,2}),
            new Ability(8, 0, 1, "Steroids", "Significantly Raises Base Health", new int[]{100, 0, 0}),
            new Ability(9, 0, 1, "Usain Bolt", "Significantly Raises Base Speed", new int[]{0,8,0}),
            new Ability(10, 0, 1, "Bench Press", "Significantly Raises Base Attack", new int[]{0,0,20}),
            new Ability(11, 0, 1, "Tank", "Signifcantly Raises Base Health, Lowers Base Speed", new int[]{300, -3, 0}),
            new Ability(12, 1, 1, "Trebuchet", "Heals and Raises Attack", new int[]{20,20, 5}),
            new Ability(13, 0, 2, "Gym Rat", "High Boost to Base Stats", new int[]{20,5, 20 }),
            new Ability(14, 0, 3, "The Flash", "Ridiculous Speed Boost", new int[]{0, 20, 0}),
            new Ability(15, 0, 5, "Superman", "Very Large Base Stat Boost", new int[]{1000,50,1000}),
            new Ability(16, 1, 1, "Seppuku", "Why Would Pick This", new int[]{-80, -2, -10})
        };
        Debug.Log("built");
    }

    private void Awake()
    {
        BuildDatabase();
    }

    public Ability getAbility(int id)
    {
        return abilities.Find(ability => ability.id == id);
    }

    public Ability getAbility(string title)
    {
        return abilities.Find(abilities => abilities.title == title);
    }

    public void addItem(Ability ability)
    {
        abilities.Add(ability);
    }
}
