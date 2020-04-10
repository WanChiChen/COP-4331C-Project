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
            new Ability(1, 0,"ability1", "Passive Ability", new int[]{4,4,4}),
            new Ability(2, 1,"ability2", "Active Ability", new int[]{10,10,5}),
            new Ability(3, 2,"ability3", "Damage Ability", new int[]{-10,0,5}),
            new Ability(4, 1,"ability4", "Active Ability 2", new int[]{-10,50,5}),
            new Ability(5, 1,"ability5", "Active Ability 3", new int[]{30,-10,5}),
            new Ability(6, 2,"ability6", "Damage Ability 2", new int[]{0,1,7}),
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
