using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ItemsTest
{   
    [Test]
    public void testGetItemByID()
    {
        GameObject obj;
        ItemDatabase db;
        Item testItem;

        obj = GameObject.FindGameObjectWithTag("ItemDB");
        db = obj.GetComponent<ItemDatabase>();
        db.BuildDatabase();
        testItem = db.getItem(1);

        Assert.IsNotNull(testItem);
    }

    [Test]
    public void testGetItemByString()
    {
        GameObject obj;
        ItemDatabase db;
        Item testItem;

        obj = GameObject.FindGameObjectWithTag("ItemDB");
        db = obj.GetComponent<ItemDatabase>();
        db.BuildDatabase();
        testItem = db.getItem("TestItem");

        Assert.IsNotNull(testItem);
    }

    [Test]
    public void testItemID()
    {
        GameObject obj;
        ItemDatabase db;
        Item testItem;
        int ID, testID;

        obj = GameObject.FindGameObjectWithTag("ItemDB");
        db = obj.GetComponent<ItemDatabase>();
        db.BuildDatabase();
        ID = 1;
        testItem = db.getItem(1);
        testID = testItem.id;

        Assert.AreEqual(ID, testID);
    }

    [Test]
    public void testItemTitle()
    {
        GameObject obj;
        ItemDatabase db;
        Item testItem;
        string Title, testTitle;

        obj = GameObject.FindGameObjectWithTag("ItemDB");
        db = obj.GetComponent<ItemDatabase>();
        db.BuildDatabase();
        Title = "TestItem";
        testItem = db.getItem(Title);
        testTitle = testItem.title;

        Assert.AreEqual(Title, testTitle);

    }

    [Test]
    public void testItemAttributes()
    {
        GameObject obj;
        ItemDatabase db;
        Item testItem;
        string attributeTitle;
        int attributeValue, testValue;

        obj = GameObject.FindGameObjectWithTag("ItemDB");
        db = obj.GetComponent<ItemDatabase>();
        db.BuildDatabase();
        attributeValue = 1;
        attributeTitle = "TestAttribute";

        testItem = db.getItem(1);
        testItem.stats.TryGetValue(attributeTitle, out testValue);

        Assert.AreEqual(testValue, attributeValue);

    }

    
}
