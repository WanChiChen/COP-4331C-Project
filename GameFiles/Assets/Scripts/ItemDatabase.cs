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
            new Item(1, 1, "Helmet", "A Helmet", new int[] {0,10,10,0}),
            new Item(2, 1, "Armor", "Protects you", new int[] {1,0,50,0}),
            new Item(3, 1, "Pants", "Protects you", new int[] {2,20,30,0}),
            new Item(4, 1, "Boots", "Prevents calluses", new int[] {3,10,0,3}),
            new Item(5, 1, "Sword", "Very Sharp", new int[] {2,50,0,0}),
            new Item(6, 1, "Dagger", "Very Sharp", new int[] {2,30,0,3}),
            new Item(7, 1, "Bow", "Pew Pew Pew", new int[] {2,40,0,2}),
            new Item(8, 1, "Axe", "Very Sharp", new int[] {2,40,10,0}),
            new Item(9, 1, "Big Sword", "Very Sharp", new int[] {2,100,0,-1}),
            new Item(10, 1, "Gloves", "Protects you", new int[] {2,10,10,1}),
            new Item(11, 1, "Shield", "Protects you", new int[] {2,0,100,0})
        };
    }

    private void Start()
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
