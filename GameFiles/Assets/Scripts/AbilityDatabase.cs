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
            new Ability(1, "TestAbility", "Test Ability", new int[]{4,4,4})
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
