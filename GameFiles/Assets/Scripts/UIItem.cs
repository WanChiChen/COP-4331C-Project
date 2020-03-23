using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    private Image itemImage;
    private UIItem selectedItem;

    public void OnPointerClick(PointerEventData eventData)
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
    // Start is called before the first frame update


    private void Awake()
    {
        itemImage = this.gameObject.GetComponent<Image>();
        updateItem(null); // test
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
    }
}
