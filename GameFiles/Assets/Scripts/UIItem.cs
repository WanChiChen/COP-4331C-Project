using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    private Image itemImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void updateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            itemImage.color = Color.black;
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
        itemImage = GetComponent<Image>();
        updateItem(null); // test
    }
}
