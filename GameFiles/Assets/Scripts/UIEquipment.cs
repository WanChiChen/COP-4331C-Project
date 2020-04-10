using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIEquipment : UIItem
{
    public int index;
    public PlayerEquip playerEquip;

    private void Awake()
    {
        itemImage = this.gameObject.GetComponent<Image>();
        updateItem(null);
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        playerEquip = GameObject.Find("Player").GetComponent<PlayerEquip>();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Equip clicked");
        if (this.item != null)
        {
            if (selectedItem.item != null)
            {
                if(selectedItem.item.type == 1)
                {
                    Item clone = new Item(selectedItem.item);

                    selectedItem.updateItem(this.item);
                    selectedItem.item = item;

                    item = clone;
                    updateItem(clone);

                    playerEquip.Equip(item);
                }
            }
            else
            {
                selectedItem.updateItem(this.item);
                selectedItem.item = this.item;

                updateItem(null);
                item = null;
                playerEquip.Unequip(index);
            }
        }
        else if (selectedItem.item != null)
        {
            if(selectedItem.item.type == 1)
            {
                if (selectedItem.item.modifiers[0] == index)
                {
                    updateItem(selectedItem.item);
                    item = selectedItem.item;
                    playerEquip.Equip(this.item);
                    selectedItem.item = null;
                    selectedItem.updateItem(null);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
