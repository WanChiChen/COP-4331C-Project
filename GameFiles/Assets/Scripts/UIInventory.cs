using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem> ();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int slotNum = 16; //default number of inventory slots

    private void Awake()
    {
        
        for (int i=0;i<slotNum;i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    private void Start()
    {
        if (Variables.GameLevel > 0)
        {
            updateGUI();
        }
    }

    public void updateGUI()
    {
        for(int i=0;i<slotNum;i++)
        {
            Debug.LogError("update1" + Variables.uiItems[0].item);
            uiItems[i].updateItem(Variables.uiItems[i].item);
            Debug.LogError("update2" + Variables.uiItems[0].item);
        }
    }

    public void updateSlot(int slot, Item item)
    {
        uiItems[slot].updateItem(item);
        Variables.uiItems = uiItems;
        Debug.LogError("UI3: " + Variables.uiItems[0]);
    }

    public void addItem(Item item)
    {
        updateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    public void removeItem(Item item)
    {
        updateSlot(uiItems.FindIndex(i => i.item == item), null);
    }
}
