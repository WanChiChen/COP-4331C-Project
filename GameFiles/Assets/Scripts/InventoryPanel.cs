using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;

public class InventoryPanel : MonoBehaviour
{
    public UIInventory ui;
    // Start is called before the first frame update
    void Start()
    {
        ui.gameObject.SetActive(!ui.gameObject.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetButtonDown("Inventory"))
        {
            ui.gameObject.SetActive(!ui.gameObject.activeSelf);
        }
    }
}
