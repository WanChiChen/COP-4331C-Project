using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    public void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, 1, "TestEquipment", "Test Description", new int[] {0,10,0,0})
        };
    }

    private void Awake()
    {
        BuildDatabase();
    }

    public Item getItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item getItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    public void addItem(Item item)
    {
        items.Add(item);
    }
}
