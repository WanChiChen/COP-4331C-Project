using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    private Text toolTip;
    private GameObject toolTipObject;

    private void Awake()
    {
        toolTip = this.gameObject.GetComponent<Text>();
        toolTipObject = GameObject.Find("ItemToolTip");
    }
    // Start is called before the first frame update
    void Start()
    {
        toolTipObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateToolTip(Item item)
    {
        string stats = "";
        string description = "";
        string slot = "";

        stats = "Base Health Increase: " + item.modifiers[1] +
                    "\nBase Damage Increase: " + item.modifiers[2] +
                    "\nBase Speed Increase: " + item.modifiers[3];

        description = "Equipable Item. " + description;

        slot = "Goes in equipment slot " + (item.modifiers[0]+1) + ".";

        toolTip.text = (item.title + "\n" + description + "\n" + stats + "\n" + slot);

    }
}
