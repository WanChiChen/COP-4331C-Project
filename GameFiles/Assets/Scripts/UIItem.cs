using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image itemImage;
    public UIItem selectedItem;
    public UIInventory ui;
    GameObject toolTipObject;
    ItemToolTip toolTip;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if(this.item != null)
        {
            if(selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.updateItem(this.item);
                updateItem(clone);
            }
            else
            {
                selectedItem.updateItem(this.item);
                updateItem(null);
            }
        }
        else if(selectedItem.item != null)
        {
            updateItem(selectedItem.item);
            selectedItem.updateItem(null);
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
            toolTipObject.SetActive(true);
            toolTip.generateToolTip(this.item);
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        toolTipObject.SetActive(false);
    }

    public void updateItem(Item item)
    {
        this.item = item;
        
        if(this.item != null)
        {
            itemImage.color = Color.white;
            itemImage.sprite = this.item.icon;
        }
        else
        {
            itemImage.color = Color.clear;
        }
    }

    void Start()
    {
        if(Variables.GameLevel == 0)
        {
            updateItem(null);
        }
        selectedItem.updateItem(null);
    }

    private void Awake()
    {
        itemImage = this.gameObject.GetComponent<Image>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        toolTipObject = GameObject.Find("ItemToolTip");
        toolTip = GameObject.Find("ItemToolTipText").GetComponent<ItemToolTip>();
        ui = GameObject.Find("InventoryPanel").GetComponent<UIInventory>();
    }
}
